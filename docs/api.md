# Tài liệu API

## Tổng quan

Hệ thống QLDA cung cấp API RESTful để tương tác với các chức năng quản lý dự án. API được tự động sinh tài liệu thông qua Swagger/OpenAPI.

## Truy cập tài liệu API

### Swagger UI
Khi chạy ứng dụng, truy cập Swagger UI tại:
```
http://localhost:{port}/swagger
```

Swagger UI cung cấp:
- Danh sách tất cả endpoints
- Mô tả chi tiết từng API
- Khả năng test API trực tiếp
- Schema của request/response
- Authentication với JWT

### OpenAPI Specification
File JSON specification có thể tải tại:
```
http://localhost:{port}/swagger/v1/swagger.json
```

## Authentication

API sử dụng JWT Bearer Token cho authentication.

### Lấy Access Token
```
POST /api/auth/login
Content-Type: application/json

{
  "username": "your_username",
  "password": "your_password"
}
```

### Sử dụng Token
Thêm header Authorization vào mỗi request:
```
Authorization: Bearer {your_jwt_token}
```

## Cấu trúc Response

Tất cả API trả về response theo format chuẩn:

```json
{
  "isSuccess": true,
  "message": "Thao tác thành công",
  "data": { ... },
  "errors": null
}
```

### Mã lỗi thường gặp
- `200`: Thành công
- `400`: Bad Request - Dữ liệu đầu vào không hợp lệ
- `401`: Unauthorized - Chưa đăng nhập hoặc token hết hạn
- `403`: Forbidden - Không có quyền truy cập
- `404`: Not Found - Không tìm thấy tài nguyên
- `500`: Internal Server Error - Lỗi hệ thống

## Các nhóm API chính

### 1. Quản lý Dự án (`/api/du-an`)
- `GET /api/du-an/danh-sach` - Lấy danh sách dự án
- `GET /api/du-an/{id}/chi-tiet` - Chi tiết dự án
- `POST /api/du-an/them-moi` - Tạo dự án mới
- `PUT /api/du-an/cap-nhat` - Cập nhật dự án
- `DELETE /api/du-an/{id}/xoa-tam` - Xóa tạm dự án

### 2. Quản lý Gói Thầu (`/api/goi-thau`)
- `GET /api/goi-thau/danh-sach` - Danh sách gói thầu
- `GET /api/goi-thau/{id}/chi-tiet` - Chi tiết gói thầu
- `POST /api/goi-thau/them-moi` - Tạo gói thầu
- `PUT /api/goi-thau/cap-nhat` - Cập nhật gói thầu

### 3. Quản lý Hợp đồng (`/api/hop-dong`)
- `GET /api/hop-dong/danh-sach` - Danh sách hợp đồng
- `GET /api/hop-dong/{id}/chi-tiet` - Chi tiết hợp đồng
- `POST /api/hop-dong/them-moi` - Tạo hợp đồng
- `PUT /api/hop-dong/cap-nhat` - Cập nhật hợp đồng

### 4. Quản lý Danh mục
- `/api/danh-muc-*` - Các API quản lý danh mục (loại dự án, nhà thầu, v.v.)

#### Danh mục tình trạng thực hiện LCNT
| Endpoint | Method | Description |
|----------|--------|-------------|
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/{id}` | GET | Lấy chi tiết theo ID |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/combobox` | GET | Danh sách cho combobox (không phân trang) |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/danh-sach` | GET | Danh sách đầy đủ (có phân trang) |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/them-moi` | POST | Tạo mới |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/cap-nhat` | PUT | Cập nhật |
| `/api/danh-muc-tinh-trang-thuc-hien-lcnt/xoa-tam` | DELETE | Xóa tạm |

### 5. Báo cáo và In ấn (`/api/print`)
- `/api/print/danh-sach-du-an` - In danh sách dự án
- `/api/print/danh-sach-goi-thau` - In danh sách gói thầu
- `/api/print/danh-sach-hop-dong` - In danh sách hợp đồng

## Quy ước chung

### Naming Convention
- Sử dụng kebab-case cho route: `danh-sach-du-an`
- Controller route: `/api/{resource}`
- Action route: `/{action}` hoặc `/{id}/{action}`

### Pagination
Các API danh sách hỗ trợ pagination:
```
GET /api/du-an/danh-sach?pageIndex=0&pageSize=10
```

### Filtering và Sorting
- `globalFilter`: Tìm kiếm toàn cục
- `sortBy`: Sắp xếp theo trường
- `sortDirection`: asc/desc

### Date Format
Sử dụng ISO 8601 format: `2024-01-15T10:30:00Z`

## Testing API

### Sử dụng Swagger UI
1. Khởi động ứng dụng
2. Truy cập `/swagger`
3. Authorize với JWT token
4. Test từng API

### Sử dụng Postman/Insomnia
1. Import OpenAPI spec từ `/swagger/v1/swagger.json`
2. Set up environment với base URL và token
3. Test các request

### Sử dụng cURL
```bash
curl -X GET "http://localhost:5000/api/du-an/danh-sach" \
     -H "Authorization: Bearer {token}" \
     -H "Content-Type: application/json"
```

## Rate Limiting

API hiện tại chưa áp dụng rate limiting. Trong môi trường production nên thêm rate limiting để bảo vệ hệ thống.

## Versioning

API hiện tại version v1. Tương lai có thể thêm versioning qua:
- URL path: `/api/v2/resource`
- Header: `Accept: application/vnd.api.v2+json`

## Bảo mật

- Tất cả API (trừ login) yêu cầu authentication
- Sử dụng HTTPS trong production
- Validate input đầu vào
- Log các thao tác quan trọng
- Áp dụng principle of least privilege

## Hỗ trợ

Để được hỗ trợ về API:
1. Kiểm tra tài liệu Swagger
2. Xem logs ứng dụng
3. Liên hệ team phát triển