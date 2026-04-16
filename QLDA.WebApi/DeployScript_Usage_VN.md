# Hướng Dẫn Sử Dụng DeployScript.ps1

## Tổng Quan
DeployScript.ps1 là script PowerShell được nâng cấp để triển khai ứng dụng một cách an toàn với thời gian downtime bằng 0.

## Cú Pháp Cơ Bản
```powershell
.\DeployScript.ps1 -SourcePath "đường dẫn nguồn" -DestinationPath "đường dẫn đích"
```

## Các Tham Số

### Tham Số Bắt Buộc
- **-SourcePath**: Đường dẫn thư mục chứa các file cần triển khai (hoặc sử dụng -ProjectPath)
- **-DestinationPath**: Đường dẫn mạng đến thư mục đích
- **-ProjectPath**: Đường dẫn đến project .NET để tự động publish (thay thế cho -SourcePath)

### Tham Số Tùy Chọn
- **-LogPath**: Đường dẫn file log (mặc định ghi ra console)
- **-ExcludePatterns**: Mảng các pattern cần loại trừ (mặc định: @("web.config", "*\PrintTemplates\*"))
- **-DeploymentMode**: Chế độ triển khai
  - "Incremental" (mặc định): Chỉ copy file được sửa đổi hôm nay
  - "Full": Copy tất cả file
- **-WhatIf**: Chế độ xem trước - chỉ hiển thị những gì sẽ làm mà không thực hiện

## Cách Chạy

### Chạy Trực Tiếp BAT File (Khuyến Nghị)
Nếu bạn muốn sử dụng đường dẫn mặc định, chỉ cần double-click file `Deploy.bat` hoặc chạy từ command prompt:

```cmd
Deploy.bat
```

File BAT này sẽ tự động publish project và triển khai đến server đích.

### Chạy PowerShell Script Trực Tiếp

#### Triển Khai Cơ Bản
```powershell
.\DeployScript.ps1 -SourcePath "C:\Build\Output" -DestinationPath "\\Server\Share\App"
```

### Triển Khai Đầy Đủ Với Log
```powershell
.\DeployScript.ps1 -SourcePath "C:\Build\Output" -DestinationPath "\\Server\Share\App" -DeploymentMode Full -LogPath "C:\Logs\deploy.log"
```

### Chế Độ Xem Trước
```powershell
.\DeployScript.ps1 -SourcePath "C:\Build\Output" -DestinationPath "\\Server\Share\App" -WhatIf
```

### Tùy Chỉnh Loại Trừ
```powershell
.\DeployScript.ps1 -SourcePath "C:\Build\Output" -DestinationPath "\\Server\Share\App" -ExcludePatterns @("*.tmp", "*\Logs\*", "web.config")
```

## Quy Trình Triển Khai

1. **Publish Project** (nếu sử dụng -ProjectPath): Chạy `dotnet publish` để build và tạo output
2. **Kiểm Tra Đường Dẫn**: Script sẽ kiểm tra tính tồn tại và quyền truy cập của các đường dẫn
3. **Offline Ứng Dụng**: Đổi tên `app_offline_.htm` để đưa ứng dụng offline
4. **Chờ Ứng Dụng Unload**: Đợi 10 giây để IIS hoàn toàn unload application domain
5. **Copy File**: Sao chép file theo chế độ đã chọn (với retry logic nếu file bị lock)
6. **Online Ứng Dụng**: Đổi tên lại file để đưa ứng dụng online

## Lưu Ý Quan Trọng

- Đảm bảo có quyền đọc từ thư mục nguồn và ghi vào thư mục đích
- File `app_offline_.html` phải tồn tại trong thư mục đích để có downtime bằng 0
- Trong chế độ Incremental, chỉ file được sửa đổi trong ngày hiện tại mới được copy
- Sử dụng `-WhatIf` để kiểm tra trước khi triển khai thực sự

## Xử Lý Lỗi

Script sẽ:
- Ghi log chi tiết về tất cả hoạt động
- Dừng lại và báo lỗi nếu gặp vấn đề nghiêm trọng
- Tự động rollback: đưa ứng dụng trở lại online nếu deployment thất bại
- Chờ 3 giây sau khi rollback để đảm bảo ứng dụng hoạt động bình thường

## Log Files

Khi chỉ định `-LogPath`, file log sẽ chứa:
- Thời gian bắt đầu và kết thúc
- Các file đã được copy
- Các lỗi gặp phải
- Trạng thái tổng thể của quá trình triển khai

## Ví Dụ Log
```
[2025-09-23 15:41:22] [INFO] === Deployment Script Started ===
[2025-09-23 15:41:22] [INFO] Validating paths...
[2025-09-23 15:41:22] [INFO] Path validation completed.
[2025-09-23 15:41:22] [INFO] Getting files to deploy (Mode: Incremental)...
[2025-09-23 15:41:22] [INFO] Found 15 files modified today.
[2025-09-23 15:41:22] [INFO] Starting deployment...
[2025-09-23 15:41:22] [INFO] Application taken offline.
[2025-09-23 15:41:25] [INFO] Copied MyApp.dll to \\Server\Share\App\bin\MyApp.dll
[2025-09-23 15:41:25] [INFO] Application brought back online.
[2025-09-23 15:41:25] [INFO] Deployment completed successfully.
[2025-09-23 15:41:25] [INFO] === Deployment Script Completed ===
```

## Troubleshooting

### Lỗi "Source path does not exist"
- Kiểm tra lại đường dẫn nguồn có chính xác không
- Đảm bảo thư mục build đã hoàn thành

### Lỗi "No write access to destination"
- Kiểm tra quyền truy cập mạng
- Đảm bảo tài khoản có quyền ghi vào share folder

### Ứng dụng không offline được
- Kiểm tra file `app_offline_.html` có tồn tại không
- Có thể ứng dụng đã offline hoặc file bị lock

### File bị lock trong quá trình copy
- Script sẽ tự động retry 3 lần với delay 2 giây giữa các lần
- Nếu vẫn thất bại, kiểm tra IIS có đang chạy và ứng dụng có được unload hoàn toàn không
- Có thể cần restart IIS site hoặc application pool

### Không có file nào được copy
- Trong chế độ Incremental: kiểm tra có file nào được sửa đổi hôm nay không
- Kiểm tra các pattern loại trừ có quá rộng không