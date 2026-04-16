# Tính năng và Use Cases chính

## 1. Quản lý Dự án

### Use Cases chính:
- **Tạo mới dự án**: Cho phép tạo dự án mới với thông tin cơ bản, nguồn vốn, quy trình phê duyệt
- **Cập nhật thông tin dự án**: Sửa đổi thông tin dự án, thay đổi quy trình nếu cần
- **Theo dõi tiến độ dự án**: Hiển thị trạng thái hiện tại, bước đang thực hiện, thời hạn
- **Liệt kê dự án**: Danh sách dự án với bộ lọc theo trạng thái, lĩnh vực, chủ đầu tư
- **Xóa tạm dự án**: Đánh dấu xóa dự án mà không xóa vật lý
- **Danh sách dự án trễ hạn**: Báo cáo các dự án đang trễ tiến độ

### Quy trình nghiệp vụ:
1. Khởi tạo dự án với thông tin cơ bản
2. Phân bổ nguồn vốn
3. Thiết lập quy trình phê duyệt
4. Thực hiện theo từng bước quy trình
5. Giám sát và báo cáo tiến độ
6. Nghiệm thu và bàn giao

## 2. Quản lý Gói Thầu

### Use Cases chính:
- **Lập kế hoạch lựa chọn nhà thầu**: Tạo KHL CNT cho gói thầu
- **Quản lý hồ sơ mời thầu**: Upload, quản lý tài liệu đấu thầu
- **Đăng tải lên mạng**: Công bố thông tin đấu thầu
- **Quản lý kết quả đấu thầu**: Ghi nhận kết quả trúng thầu
- **Theo dõi tiến độ gói thầu**: Trạng thái từ lập KH đến trúng thầu

## 3. Quản lý Hợp đồng

### Use Cases chính:
- **Tạo hợp đồng**: Ký kết hợp đồng với nhà thầu trúng thầu
- **Quản lý phụ lục hợp đồng**: Thêm/sửa phụ lục khi có thay đổi
- **Theo dõi thực hiện hợp đồng**: Tiến độ, thanh toán, nghiệm thu
- **Quản lý thanh toán**: Thanh toán theo tiến độ, tạm ứng, quyết toán

## 4. Quản lý Tài chính

### Use Cases chính:
- **Tạm ứng**: Cấp phát tạm ứng cho nhà thầu
- **Thanh toán**: Thanh toán theo khối lượng hoàn thành
- **Quyết toán**: Quyết toán cuối cùng khi hoàn thành hợp đồng

## 5. Báo cáo và Nghiệm thu

### Use Cases chính:
- **Báo cáo tiến độ**: Báo cáo định kỳ về tình hình thực hiện
- **Báo cáo bàn giao sản phẩm**: Báo cáo khi bàn giao sản phẩm
- **Báo cáo bảo hành**: Theo dõi bảo hành sau bàn giao
- **Nghiệm thu**: Nghiệm thu từng giai đoạn và nghiệm thu tổng thể

## 6. Quản lý Văn bản và Quyết định

### Use Cases chính:
- **Quyết định phê duyệt dự án**: Tạo QĐ duyệt dự án, nguồn vốn
- **Quyết định duyệt KHLCNT**: Phê duyệt kế hoạch lựa chọn nhà thầu
- **Quyết định duyệt quyết toán**: Phê duyệt quyết toán
- **Lập ban QLDA**: Thành lập ban quản lý dự án
- **Lập hội đồng thẩm định**: Thành lập hội đồng đánh giá
- **Văn bản pháp lý**: Quản lý các văn bản pháp lý liên quan

## 7. Quản lý Danh mục

### Use Cases chính:
- **Danh mục chủ đầu tư**: Quản lý danh sách chủ đầu tư
- **Danh mục nhà thầu**: Thông tin nhà thầu tham gia đấu thầu
- **Danh mục loại dự án**: Phân loại dự án theo tính chất
- **Danh mục quy trình**: Các quy trình phê duyệt chuẩn
- **Danh mục trạng thái**: Trạng thái của dự án, gói thầu, hợp đồng
- **Danh mục tình trạng thực hiện LCNT**: Quản lý trạng thái thực hiện LCNT - Lựa chọn nhà thầu (chưa thực hiện, đang thực hiện, đã thực hiện, ...) [UC-21]

## 8. Hệ thống và Bảo mật

### Use Cases chính:
- **Xác thực người dùng**: Đăng nhập, phân quyền
- **Quản lý người dùng**: Thêm/sửa/xóa tài khoản
- **Phân quyền**: Phân quyền theo vai trò, chức năng
- **Audit log**: Ghi log các thao tác quan trọng

## 9. Báo cáo và Thống kê

### Use Cases chính:
- **Báo cáo tổng hợp**: Báo cáo tình hình dự án theo nhiều tiêu chí
- **Thống kê theo lĩnh vực**: Phân tích theo ngành nghề
- **Thống kê theo chủ đầu tư**: Theo dõi dự án của từng chủ đầu tư
- **Báo cáo trễ hạn**: Danh sách dự án trễ tiến độ

## Quy tắc nghiệp vụ chung

- Tất cả dự án phải tuân thủ quy trình phê duyệt đã định
- Mỗi bước trong quy trình có thời hạn thực hiện
- Hệ thống tự động cảnh báo khi đến hạn hoặc trễ hạn
- Các thay đổi quan trọng được ghi log để audit
- Tài liệu đính kèm được lưu trữ và quản lý tập trung