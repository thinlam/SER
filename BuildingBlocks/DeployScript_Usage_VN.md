# Hướng Dẫn Sử Dụng Deployment & Migration Scripts

## Tổng Quan

BuildingBlocks cung cấp unified scripts để deploy và quản lý database migrations cho tất cả modules.

## Các Module Hỗ Trợ

| Module | Tên đầy đủ | Destination |
|--------|------------|-------------|
| DVDC | Dịch vụ dùng chung | `\\192.168.1.12\api_mnd\TTCDS\DichVuDungChung` |
| QLDA | Quản lý dự án | `\\192.168.1.12\api_mnd\TTCDS\QuanLyDuAn` |
| NVTT | Nhiệm vụ trọng tâm | `\\192.168.1.12\api_mnd\TTCDS\NhiemVuTrongTam` |
| QLHD | Quản lý hợp đồng | `\\192.168.1.12\api_mnd\TTCDS\QuanLyHopDong` |

---

## Deploy Script (deploy.bat)

### Cú Pháp
```cmd
deploy.bat <Module> [Environment] [DeploymentMode]
```

### Tham Số
| Tham số | Giá trị | Mặc định |
|---------|---------|----------|
| Module | DVDC, QLDA, NVTT, QLHD | **Required** |
| Environment | Staging, Production | Staging |
| DeploymentMode | Incremental, Full | Incremental |

### Ví Dụ
```cmd
# Deploy QLHD to staging (incremental)
deploy.bat QLHD

# Deploy DVDC with full mode
deploy.bat DVDC Staging Full

# Build NVTT for production
deploy.bat NVTT Production

# Deploy QLDA to staging
deploy.bat QLDA
```

### Deployment Modes
- **Incremental**: Chỉ copy file được sửa đổi hôm nay, giữ nguyên web.config và PrintTemplates
- **Full**: Copy tất cả file, tạo backup, bao gồm web.config và PrintTemplates

---

## EF Migration Script (ef.bat)

### Cú Pháp
```cmd
ef.bat <Module> <Command> [MigrationName]
```

### Tham Số
| Tham số | Giá trị | Mô tả |
|---------|---------|-------|
| Module | DVDC, QLDA, NVTT, QLHD | Module cần thao tác |
| Command | add, remove, update, list | Lệnh EF Core |
| MigrationName | Tên migration | Required cho 'add' |

### Các Lệnh

#### Add Migration
```cmd
ef.bat QLHD add AddUserTable
ef.bat DVDC add AddNewColumn
ef.bat NVTT add CreateLogTable
```

#### Remove Last Migration
```cmd
ef.bat QLHD remove
ef.bat DVDC remove
```

#### Update Database
```cmd
# Update to latest
ef.bat QLHD update

# Update to specific migration
ef.bat QLHD update 20260323061913

# Rollback all migrations
ef.bat QLHD update 0
```

#### List Migrations
```cmd
ef.bat QLHD list
ef.bat DVDC list
```

---

## Quick Reference

### Deploy
```cmd
deploy.bat QLHD                    # QLHD → Staging (Incremental)
deploy.bat DVDC Staging Full       # DVDC → Staging (Full)
deploy.bat NVTT Production         # NVTT → Production build
```

### Migration
```cmd
ef.bat QLHD add AddNewTable        # Create migration
ef.bat QLHD update                 # Apply migrations
ef.bat QLHD list                   # View migrations
ef.bat QLHD remove                 # Remove last migration
```

---

## Quy Trình Deploy

1. **Publish**: `dotnet publish` project WebApi
2. **Cleanup**: Xóa file không cần thiết (tests, configs, scripts)
3. **Update web.config**: Set ASPNETCORE_ENVIRONMENT
4. **Copy**: Deploy to server (nếu không phải Production)

## Quy Trình Migration

1. **Tạo migration**: `ef.bat <Module> add <Name>`
2. **Review**: Kiểm tra file migration được tạo
3. **Apply**: `ef.bat <Module> update`
4. **Verify**: Kiểm tra database đã update đúng

---

## Legacy Scripts (Vẫn hoạt động)

| Script | Module | Ghi chú |
|--------|--------|---------|
| `Deploy.bat` | DVDC | Giữ nguyên cho backward compatibility |

---

## Troubleshooting

### Deploy Failed
- Kiểm tra quyền truy cập network share
- Đảm bảo IIS site đang chạy
- Kiểm tra file `app_offline_.htm` tồn tại

### Migration Failed
- Kiểm tra connection string trong `appsettings.json`
- Đảm bảo database server accessible
- Chạy `ef.bat <Module> list` để xem trạng thái

### Build Failed
- Chạy từ BuildingBlocks root directory
- Kiểm tra .NET SDK version (net8.0)
- Run `dotnet restore` nếu thiếu packages