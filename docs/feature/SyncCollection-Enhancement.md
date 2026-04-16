# SyncCollection Enhancement: Handle Empty Request to Delete All

## Mô tả tính năng (Feature Description)

Tính năng này cải thiện phương thức `SyncCollection` trong `QLDA.Application\Common\SyncHelper.cs` để xử lý trường hợp request rỗng (null hoặc empty), bằng cách xóa mềm tất cả entities hiện tại.

## Workflow thực hiện (Implementation Workflow)

1. **Phân tích yêu cầu**: Xác định rằng phương thức `SyncCollection` thiếu xử lý cho trường hợp `requestEntities` rỗng, dẫn đến lỗi hoặc hành vi không mong muốn.

2. **Thiết kế giải pháp**:
   - Thêm kiểm tra `if (requestEntities == null || !requestEntities.Any())` ngay sau snapshot.
   - Nếu request rỗng, đặt `IsDeleted = true` cho tất cả entities hiện tại chưa bị xóa.
   - Trả về sớm để tránh xử lý tiếp theo.

3. **Cập nhật tài liệu**: Cập nhật comment của phương thức để phản ánh 5 trường hợp thay vì 4.

4. **Triển khai code**: Thêm logic xử lý vào phương thức `SyncCollection`.

5. **Kiểm tra build**: Chạy `dotnet build` để đảm bảo không có lỗi biên dịch.

6. **Tài liệu hóa**: Tạo file này để mô tả workflow và đánh giá ưu nhược điểm.

## Ưu điểm (Pros)

- **Đơn giản và rõ ràng**: Logic xử lý trường hợp edge case một cách trực tiếp, dễ hiểu và maintain.
- **Ngăn ngừa lỗi**: Tránh exception khi `requestEntities` là null, bằng cách xử lý sớm.
- **Tính nhất quán**: Đảm bảo hành vi đồng nhất cho tất cả QueryHandler sử dụng GlobalFilter, không cần truyền thêm tham số.
- **Hiệu suất**: Trả về sớm khi request rỗng, tránh tính toán không cần thiết.
- **An toàn**: Chỉ xóa mềm (soft delete), không xóa vĩnh viễn dữ liệu.

## Nhược điểm (Cons)

- **Hành vi ngầm định**: Việc xóa tất cả khi request rỗng có thể không rõ ràng cho developer sử dụng phương thức, cần tài liệu tốt.
- **Không linh hoạt**: Không cho phép tùy chỉnh hành vi (ví dụ: có thể muốn giữ nguyên thay vì xóa khi request rỗng).
- **Phụ thuộc vào soft delete**: Giả định rằng hệ thống sử dụng soft delete, nếu không thì cần thay đổi.
- **Khó debug**: Nếu request rỗng do lỗi upstream, việc xóa tất cả có thể che giấu vấn đề gốc.
- **Không backward compatible**: Thay đổi hành vi có thể ảnh hưởng đến code hiện tại nếu dựa vào hành vi cũ.

## Kết luận (Conclusion)

Cách làm này phù hợp cho hệ thống cần đồng bộ dữ liệu với khả năng xóa hàng loạt thông qua request rỗng, đặc biệt khi sử dụng GlobalFilter trên nhiều QueryHandler. Ưu điểm về tính nhất quán và ngăn ngừa lỗi outweigh nhược điểm về tính linh hoạt, miễn là được tài liệu hóa rõ ràng.