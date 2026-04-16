# QLHD WebAPI - FE API Mapping Report

**Generated:** 2026-03-26
**Module:** Quản lý hợp đồng (QLHD)
**Base URL:** `/api/qlhd/`

---

## Version History

| Version | Date       | Changes                           |
| ------- | ---------- | --------------------------------- |
| v0.0.1  | 2026-03-25 | Initial documentation             |
| v0.0.2  | 2026-03-26 | Add CongViec entity (Full CRUD)   |

---

## 📋 Thay đổi v0.0.2 → v0.0.1 (Dành cho Frontend)

### Tóm tắt

| Loại thay đổi | Chi tiết |
|---------------|----------|
| **API mới** | 5 endpoint cho entity `CongViec` |
| **Breaking changes** | Không |
| **Backward compatible** | Có ✓ |

### API Mới: Công việc (CongViec)

Entity `CongViec` dùng để quản lý công việc theo dự án.

#### Endpoints mới cần tích hợp:

| Method | Endpoint | Mô tả | FE Action |
|--------|----------|-------|-----------|
| `POST` | `/api/qlhd/cong-viec/them-moi` | Tạo công việc mới | Thêm form tạo CV |
| `PUT` | `/api/qlhd/cong-viec/cap-nhat/{id}` | Cập nhật công việc | Form sửa CV |
| `GET` | `/api/qlhd/cong-viec/danh-sach?duAnId={id}` | Danh sách CV theo dự án | Bảng danh sách CV |
| `GET` | `/api/qlhd/cong-viec/chi-tiet/{id}` | Chi tiết công việc | Trang chi tiết CV |
| `DELETE` | `/api/qlhd/cong-viec/xoa/{id}` | Xóa công việc | Button xóa CV |

#### Lưu ý quan trọng cho FE:

1. **Bắt buộc filter theo dự án:**
   ```typescript
   // ❌ Sai - sẽ không trả về dữ liệu
   GET /api/qlhd/cong-viec/danh-sach

   // ✅ Đúng - phải có duAnId
   GET /api/qlhd/cong-viec/danh-sach?duAnId=abc-123-...
   ```

2. **Kiểu dữ liệu `thoiGian`:**
   ```typescript
   // MonthYear format: "MM-yyyy"
   interface CongViecDto {
     thoiGian: string;  // "03-2026", "12-2025", ...
   }

   // Khi gửi request:
   {
     "thoiGian": "03-2026"  // Format: MM-yyyy
   }
   ```

3. **Search string tìm trong:**
   - `nguoiThucHien` (Tên người thực hiện)
   - `keHoachCongViec` (Kế hoạch công việc)
   - `thucTe` (Thực tế)

#### TypeScript Interface cho FE:

```typescript
// types/cong-viec.ts

/** Key type: Guid → string trong TypeScript */
interface CongViecDto {
  id: string;
  duAnId: string;
  thoiGian: string;           // Format: "MM-yyyy"
  userPortalId: number;
  nguoiThucHien: string;
  donViId: number;
  tenDonVi: string;
  phongBanId?: number;
  tenPhongBan?: string;
  keHoachCongViec: string;    // Max 2000 chars
  ngayHoanThanh?: string;     // DateOnly: "yyyy-MM-dd"
  thucTe?: string;            // Max 2000 chars
  trangThaiId: number;
  tenTrangThai: string;
  tenDuAn?: string;
}

interface CongViecSearchModel {
  duAnId: string;             // Required!
  searchString?: string;
  pageNumber: number;
  pageSize: number;
}

interface CongViecInsertModel {
  duAnId: string;             // Required
  thoiGian: string;           // "MM-yyyy"
  userPortalId: number;       // Required
  donViId: number;            // Required
  phongBanId?: number;
  keHoachCongViec: string;    // Max 2000 chars
  ngayHoanThanh?: string;      // "yyyy-MM-dd"
  thucTe?: string;            // Max 2000 chars
  trangThaiId: number;        // Required
}
```

#### API Service Example:

```typescript
// services/cong-viec.service.ts

const BASE_URL = '/api/qlhd/cong-viec';

export const congViecApi = {
  // Lấy danh sách - PHẢI có duAnId
  getList: (duAnId: string, params: Partial<CongViecSearchModel>) =>
    axios.get<PaginatedList<CongViecDto>>(`${BASE_URL}/danh-sach`, {
      params: { duAnId, ...params }
    }),

  // Lấy chi tiết
  getById: (id: string) =>
    axios.get<CongViecDto>(`${BASE_URL}/chi-tiet/${id}`),

  // Tạo mới
  create: (model: CongViecInsertModel) =>
    axios.post<CongViecDto>(`${BASE_URL}/them-moi`, model),

  // Cập nhật
  update: (id: string, model: CongViecUpdateModel) =>
    axios.put<CongViecDto>(`${BASE_URL}/cap-nhat/${id}`, model),

  // Xóa
  delete: (id: string) =>
    axios.delete(`${BASE_URL}/xoa/${id}`),
};
```

### 📝 Cập nhật Search Model cho DuAn (v0.0.2)

Endpoint `du-an/danh-sach` có thêm các filter mới:

#### TypeScript Interface:

```typescript
// types/du-an.ts

interface DuAnSearchModel {
  // Pagination
  pageNumber: number;
  pageSize: number;

  // Full-text search
  searchString?: string;         // Search in Ten

  // Filters
  tuNgayDuKien?: string;         // "yyyy-MM-dd" - from date
  denNgayDuKien?: string;        // "yyyy-MM-dd" - to date
  giamDocId?: number;            // Filter by Director
  phongBanIds?: number[];        // Filter by departments (matches PhongBanPhuTrachChinhId OR PhongBanPhoiHops)
  nguoiPhuTrachId?: number;      // Filter by Person in charge
  nguoiTheoDoiId?: number;       // Filter by Supervisor
}
```

#### API Service Example:

```typescript
// services/du-an.service.ts

const BASE_URL = '/api/qlhd/du-an';

export const duAnApi = {
  // Lấy danh sách với filter
  getList: (params: Partial<DuAnSearchModel>) =>
    axios.get<PaginatedList<DuAnDto>>(`${BASE_URL}/danh-sach`, { params }),

  // Lọc theo phòng ban (match cả phụ trách chính và phối hợp)
  getByPhongBan: (phongBanIds: number[], params?: Partial<DuAnSearchModel>) =>
    axios.get<PaginatedList<DuAnDto>>(`${BASE_URL}/danh-sach`, {
      params: { phongBanIds, ...params }
    }),

  // Lọc theo khoảng thời gian dự kiến
  getByDateRange: (tuNgay: string, denNgay: string, params?: Partial<DuAnSearchModel>) =>
    axios.get<PaginatedList<DuAnDto>>(`${BASE_URL}/danh-sach`, {
      params: { tuNgayDuKien: tuNgay, denNgayDuKien: denNgay, ...params }
    }),
};
```

#### Lưu ý cho FE:
- `phongBanIds`: Mảng ID phòng ban. Match nếu `PhongBanPhuTrachChinhId` **HOẶC** bất kỳ `PhongBanPhoiHops` chứa ID đó
- `tuNgayDuKien`/`denNgayDuKien`: Filter theo `ThoiGianDuKien` (thời gian dự kiến hoàn thành)

### So sánh số lượng API

| Version | Controllers | Endpoints |
|---------|-------------|-----------|
| v0.0.1  | 13          | ~65       |
| v0.0.2  | 14 (+1)     | ~70 (+5)  |

### Không có Breaking Changes

Tất cả API v0.0.1 vẫn hoạt động bình thường. FE chỉ cần thêm tích hợp cho `CongViec` nếu cần.

---

## Table of Contents

1. [Danh mục (Master Data)](#part-a-danh-mục-master-data)
2. [Business Entities](#part-b-business-entities)
3. [Legacy/Reference](#part-c-legacyreference)

---

# Part A: Danh mục (Master Data)

## 1. Danh mục giám đốc (DanhMucGiamDoc)

**Base Route:** `danh-muc-giam-doc`
**Key Type:** `Guid`
**Type:** Full CRUD

| Phương thức | Đường dẫn                         | Mô tả                           | Request                             | Response                           |
| ----------- | --------------------------------- | ------------------------------- | ----------------------------------- | ---------------------------------- |
| POST        | `danh-muc-giam-doc/them-moi`      | Thêm mới giám đốc               | `DanhMucGiamDocInsertModel`         | `DanhMucGiamDocDto`                |
| PUT         | `danh-muc-giam-doc/cap-nhat/{id}` | Cập nhật giám đốc               | `DanhMucGiamDocUpdateModel`         | `DanhMucGiamDocDto`                |
| GET         | `danh-muc-giam-doc/danh-sach`     | Danh sách giám đốc (phân trang) | `DanhMucGiamDocSearchModel` (query) | `PaginatedList<DanhMucGiamDocDto>` |
| GET         | `danh-muc-giam-doc/chi-tiet/{id}` | Chi tiết giám đốc               | -                                   | `DanhMucGiamDocDto`                |
| GET         | `danh-muc-giam-doc/combobox`      | Danh sách combobox              | -                                   | `List<ComboBoxDto<Guid>>`          |
| DELETE      | `danh-muc-giam-doc/xoa/{id}`      | Xóa giám đốc                    | -                                   | `ResultApi`                        |

**Response DTO:**
```json
{
  "id": "Guid",
  "ma": "string",
  "ten": "string",
  "moTa": "string?",
  "used": "bool",
  "userPortalId": "int?"
}
```

---

## 2. Danh mục người phụ trách (DanhMucNguoiPhuTrach)

**Base Route:** `danh-muc-nguoi-phu-trach`
**Key Type:** `Guid`
**Type:** Full CRUD

| Phương thức | Đường dẫn                                | Mô tả                                  | Request                                   | Response                                 |
| ----------- | ---------------------------------------- | -------------------------------------- | ----------------------------------------- | ---------------------------------------- |
| POST        | `danh-muc-nguoi-phu-trach/them-moi`      | Thêm mới người phụ trách               | `DanhMucNguoiPhuTrachInsertModel`         | `DanhMucNguoiPhuTrachDto`                |
| PUT         | `danh-muc-nguoi-phu-trach/cap-nhat/{id}` | Cập nhật người phụ trách               | `DanhMucNguoiPhuTrachUpdateModel`         | `DanhMucNguoiPhuTrachDto`                |
| GET         | `danh-muc-nguoi-phu-trach/danh-sach`     | Danh sách người phụ trách (phân trang) | `DanhMucNguoiPhuTrachSearchModel` (query) | `PaginatedList<DanhMucNguoiPhuTrachDto>` |
| GET         | `danh-muc-nguoi-phu-trach/chi-tiet/{id}` | Chi tiết người phụ trách               | -                                         | `DanhMucNguoiPhuTrachDto`                |
| GET         | `danh-muc-nguoi-phu-trach/combobox`      | Danh sách combobox                     | -                                         | `List<ComboBoxDto<Guid>>`                |
| DELETE      | `danh-muc-nguoi-phu-trach/xoa/{id}`      | Xóa người phụ trách                    | -                                         | `ResultApi`                              |

**Response DTO:**
```json
{
  "id": "Guid",
  "ma": "string",
  "ten": "string",
  "moTa": "string?",
  "used": "bool",
  "userPortalId": "int?"
}
```

---

## 3. Danh mục người theo dõi (DanhMucNguoiTheoDoi)

**Base Route:** `danh-muc-nguoi-theo-doi`
**Key Type:** `Guid`
**Type:** Full CRUD

| Phương thức | Đường dẫn                               | Mô tả                                 | Request                                  | Response                                |
| ----------- | --------------------------------------- | ------------------------------------- | ---------------------------------------- | --------------------------------------- |
| POST        | `danh-muc-nguoi-theo-doi/them-moi`      | Thêm mới người theo dõi               | `DanhMucNguoiTheoDoiInsertModel`         | `DanhMucNguoiTheoDoiDto`                |
| PUT         | `danh-muc-nguoi-theo-doi/cap-nhat/{id}` | Cập nhật người theo dõi               | `DanhMucNguoiTheoDoiUpdateModel`         | `DanhMucNguoiTheoDoiDto`                |
| GET         | `danh-muc-nguoi-theo-doi/danh-sach`     | Danh sách người theo dõi (phân trang) | `DanhMucNguoiTheoDoiSearchModel` (query) | `PaginatedList<DanhMucNguoiTheoDoiDto>` |
| GET         | `danh-muc-nguoi-theo-doi/chi-tiet/{id}` | Chi tiết người theo dõi               | -                                        | `DanhMucNguoiTheoDoiDto`                |
| GET         | `danh-muc-nguoi-theo-doi/combobox`      | Danh sách combobox                    | -                                        | `List<ComboBoxDto<Guid>>`               |
| DELETE      | `danh-muc-nguoi-theo-doi/xoa/{id}`      | Xóa người theo dõi                    | -                                        | `ResultApi`                             |

**Response DTO:**
```json
{
  "id": "Guid",
  "ma": "string",
  "ten": "string",
  "moTa": "string?",
  "used": "bool",
  "userPortalId": "int?"
}
```

---

## 4. Danh mục loại trạng thái (DanhMucLoaiTrangThai)

**Base Route:** `danh-muc-loai-trang-thai`
**Key Type:** `int`
**Type:** Full CRUD

| Phương thức | Đường dẫn                                | Mô tả                                  | Request                                   | Response                                 |
| ----------- | ---------------------------------------- | -------------------------------------- | ----------------------------------------- | ---------------------------------------- |
| POST        | `danh-muc-loai-trang-thai/them-moi`      | Thêm mới loại trạng thái               | `DanhMucLoaiTrangThaiInsertModel`         | `DanhMucLoaiTrangThaiDto`                |
| PUT         | `danh-muc-loai-trang-thai/cap-nhat/{id}` | Cập nhật loại trạng thái               | `DanhMucLoaiTrangThaiUpdateModel`         | `DanhMucLoaiTrangThaiDto`                |
| GET         | `danh-muc-loai-trang-thai/danh-sach`     | Danh sách loại trạng thái (phân trang) | `DanhMucLoaiTrangThaiSearchModel` (query) | `PaginatedList<DanhMucLoaiTrangThaiDto>` |
| GET         | `danh-muc-loai-trang-thai/chi-tiet/{id}` | Chi tiết loại trạng thái               | -                                         | `DanhMucLoaiTrangThaiDto`                |
| GET         | `danh-muc-loai-trang-thai/combobox`      | Danh sách combobox                     | -                                         | `List<ComboBoxDto<int>>`                 |
| DELETE      | `danh-muc-loai-trang-thai/xoa/{id}`      | Xóa loại trạng thái                    | -                                         | `ResultApi`                              |

**Response DTO:**
```json
{
  "id": "int",
  "ma": "string",
  "ten": "string",
  "moTa": "string?",
  "used": "bool"
}
```

---

## 5. Danh mục trạng thái (DanhMucTrangThai)

**Base Route:** `danh-muc-trang-thai`
**Key Type:** `int`
**Type:** Full CRUD

| Phương thức | Đường dẫn                           | Mô tả                             | Request                               | Response                             |
| ----------- | ----------------------------------- | --------------------------------- | ------------------------------------- | ------------------------------------ |
| POST        | `danh-muc-trang-thai/them-moi`      | Thêm mới trạng thái               | `DanhMucTrangThaiInsertModel`         | `DanhMucTrangThaiDto`                |
| PUT         | `danh-muc-trang-thai/cap-nhat/{id}` | Cập nhật trạng thái               | `DanhMucTrangThaiUpdateModel`         | `DanhMucTrangThaiDto`                |
| GET         | `danh-muc-trang-thai/danh-sach`     | Danh sách trạng thái (phân trang) | `DanhMucTrangThaiSearchModel` (query) | `PaginatedList<DanhMucTrangThaiDto>` |
| GET         | `danh-muc-trang-thai/chi-tiet/{id}` | Chi tiết trạng thái               | -                                     | `DanhMucTrangThaiDto`                |
| GET         | `danh-muc-trang-thai/combobox`      | Danh sách combobox                | `loaiTrangThaiId` (query, optional)   | `List<ComboBoxDto<int>>`             |
| DELETE      | `danh-muc-trang-thai/xoa/{id}`      | Xóa trạng thái                    | -                                     | `ResultApi`                          |

**Response DTO:**
```json
{
  "id": "int",
  "ma": "string",
  "ten": "string",
  "moTa": "string?",
  "used": "bool",
  "loaiTrangThaiId": "int",
  "maLoaiTrangThai": "string",
  "tenLoaiTrangThai": "string"
}
```

---

## 6. Danh mục loại hợp đồng (DanhMucLoaiHopDong)

**Base Route:** `danh-muc-loai-hop-dong`
**Key Type:** `int`
**Type:** Full CRUD

| Phương thức | Đường dẫn                              | Mô tả                                | Request                                 | Response                               |
| ----------- | -------------------------------------- | ------------------------------------ | --------------------------------------- | -------------------------------------- |
| POST        | `danh-muc-loai-hop-dong/them-moi`      | Thêm mới loại hợp đồng               | `DanhMucLoaiHopDongInsertModel`         | `DanhMucLoaiHopDongDto`                |
| PUT         | `danh-muc-loai-hop-dong/cap-nhat/{id}` | Cập nhật loại hợp đồng               | `DanhMucLoaiHopDongUpdateModel`         | `DanhMucLoaiHopDongDto`                |
| GET         | `danh-muc-loai-hop-dong/danh-sach`     | Danh sách loại hợp đồng (phân trang) | `DanhMucLoaiHopDongSearchModel` (query) | `PaginatedList<DanhMucLoaiHopDongDto>` |
| GET         | `danh-muc-loai-hop-dong/chi-tiet/{id}` | Chi tiết loại hợp đồng               | -                                       | `DanhMucLoaiHopDongDto`                |
| GET         | `danh-muc-loai-hop-dong/combobox`      | Danh sách combobox                   | -                                       | `List<ComboBoxDto<int>>`               |
| DELETE      | `danh-muc-loai-hop-dong/xoa/{id}`      | Xóa loại hợp đồng                    | -                                       | `ResultApi`                            |

**Response DTO:**
```json
{
  "id": "int",
  "ma": "string",
  "ten": "string",
  "moTa": "string?",
  "used": "bool",
  "symbol": "string?",
  "prefix": "string?",
  "isDefault": "bool"
}
```

---

## 7. Danh mục loại thanh toán (DanhMucLoaiThanhToan)

**Base Route:** `danh-muc-loai-thanh-toan`
**Key Type:** `int`
**Type:** Full CRUD

| Phương thức | Đường dẫn                                   | Mô tả                                   | Request                                    | Response                                  |
| ----------- | ------------------------------------------- | --------------------------------------- | ------------------------------------------ | ----------------------------------------- |
| POST        | `danh-muc-loai-thanh-toan/them-moi`         | Thêm mới loại thanh toán                | `DanhMucLoaiThanhToanInsertModel`          | `DanhMucLoaiThanhToanDto`                 |
| PUT         | `danh-muc-loai-thanh-toan/cap-nhat/{id}`    | Cập nhật loại thanh toán                | `DanhMucLoaiThanhToanUpdateModel`          | `DanhMucLoaiThanhToanDto`                 |
| GET         | `danh-muc-loai-thanh-toan/danh-sach`        | Danh sách loại thanh toán (phân trang)  | `DanhMucLoaiThanhToanSearchModel` (query)  | `PaginatedList<DanhMucLoaiThanhToanDto>`  |
| GET         | `danh-muc-loai-thanh-toan/chi-tiet/{id}`    | Chi tiết loại thanh toán                | -                                          | `DanhMucLoaiThanhToanDto`                 |
| GET         | `danh-muc-loai-thanh-toan/combobox`         | Danh sách combobox                      | -                                          | `List<ComboBoxDto<int>>`                  |
| DELETE      | `danh-muc-loai-thanh-toan/xoa/{id}`         | Xóa loại thanh toán                     | -                                          | `ResultApi`                               |

**Response DTO:**
```json
{
  "id": "int",
  "ma": "string?",
  "ten": "string?",
  "moTa": "string?",
  "used": "bool",
  "isDefault": "bool"
}
```

---

# Part B: Business Entities

## 8. Doanh nghiệp (DoanhNghiep)

**Base Route:** `doanh-nghiep`
**Key Type:** `Guid`
**Type:** Full CRUD

| Phương thức | Đường dẫn                          | Mô tả                           | Request                               | Response                             |
| ----------- | ---------------------------------- | ------------------------------- | ------------------------------------- | ------------------------------------ |
| POST        | `doanh-nghiep/them-moi`            | Thêm mới doanh nghiệp           | `DoanhNghiepInsertModel`              | `DoanhNghiepDto`                     |
| PUT         | `doanh-nghiep/cap-nhat/{id}`       | Cập nhật doanh nghiệp           | `DoanhNghiepUpdateModel`              | `DoanhNghiepDto`                     |
| GET         | `doanh-nghiep/danh-sach`           | Danh sách doanh nghiệp          | `DoanhNghiepSearchModel` (query)      | `PaginatedList<DoanhNghiepDto>`      |
| GET         | `doanh-nghiep/chi-tiet/{id}`       | Chi tiết doanh nghiệp           | -                                     | `DoanhNghiepDto`                     |
| GET         | `doanh-nghiep/combobox`            | Danh sách combobox              | `search` (query, optional)            | `List<ComboBoxDto<Guid>>`            |
| DELETE      | `doanh-nghiep/xoa/{id}`            | Xóa doanh nghiệp                | -                                     | `ResultApi`                          |

**Response DTO:**
```json
{
  "id": "Guid",
  "taxCode": "string?",
  "ten": "string?",
  "tenTiengAnh": "string?",
  "taxAuthorityId": "int?",
  "phone": "string?",
  "fax": "string?",
  "addressVN": "string?",
  "addressEN": "string?",
  "countryId": "int?",
  "cityId": "int?",
  "districtId": "int?",
  "email": "string?",
  "contactPerson": "string?",
  "owner": "string?",
  "bankAccount": "string?",
  "accountHolder": "string?",
  "bankName": "string?",
  "isLogo": "bool",
  "logoFileName": "string?",
  "moTa": "string?",
  "isActive": "bool",
  "authorizeVolume": "string?",
  "authorizeLic": "string?",
  "authorizeDate": "DateTime?",
  "version": "string?"
}
```

---

## 9. Khách hàng (KhachHang)

**Base Route:** `khach-hang`
**Key Type:** `Guid`
**Type:** Full CRUD

| Phương thức | Đường dẫn                     | Mô tả                       | Request                            | Response                          |
| ----------- | ----------------------------- | --------------------------- | ---------------------------------- | --------------------------------- |
| POST        | `khach-hang/them-moi`         | Thêm mới khách hàng         | `KhachHangInsertModel`             | `KhachHangDto`                    |
| PUT         | `khach-hang/cap-nhat/{id}`    | Cập nhật khách hàng         | `KhachHangUpdateModel`             | `KhachHangDto`                    |
| GET         | `khach-hang/danh-sach`        | Danh sách khách hàng        | `KhachHangSearchModel` (query)     | `PaginatedList<KhachHangDto>`     |
| GET         | `khach-hang/chi-tiet/{id}`    | Chi tiết khách hàng         | -                                  | `KhachHangDto`                    |
| GET         | `khach-hang/combobox`         | Danh sách combobox          | -                                  | `List<ComboBoxDto<Guid>>`         |
| DELETE      | `khach-hang/xoa/{id}`         | Xóa khách hàng              | -                                  | `ResultApi`                       |

**Response DTO:**
```json
{
  "id": "Guid",
  "ma": "string?",
  "ten": "string?",
  "isPersonal": "bool",
  "dateOfBirth": "DateOnly?",
  "taxCode": "string?",
  "contactPerson": "string?",
  "address": "string?",
  "phone": "string?",
  "email": "string?",
  "districtId": "int?",
  "districtName": "string?",
  "cityId": "int?",
  "cityName": "string?",
  "countryId": "int?",
  "countryName": "string?",
  "isDefault": "bool",
  "used": "bool",
  "donViId": "long?",
  "doanhNghiepId": "Guid?"
}
```

---

## 10. Dự án (DuAn)

**Base Route:** `du-an`
**Key Type:** `Guid`
**Type:** Full CRUD (no combobox)

| Phương thức | Đường dẫn               | Mô tả                | Request                        | Response                    |
| ----------- | ----------------------- | -------------------- | ------------------------------ | --------------------------- |
| POST        | `du-an/them-moi`        | Thêm mới dự án       | `DuAnInsertModel`              | `DuAnDto`                   |
| PUT         | `du-an/cap-nhat/{id}`   | Cập nhật dự án       | `DuAnUpdateModel`              | `DuAnDto`                   |
| GET         | `du-an/danh-sach`       | Danh sách dự án      | `DuAnSearchModel` (query)      | `PaginatedList<DuAnDto>`    |
| GET         | `du-an/chi-tiet/{id}`   | Chi tiết dự án       | -                              | `DuAnDto`                   |
| DELETE      | `du-an/xoa/{id}`        | Xóa dự án            | -                              | `ResultApi`                 |

**Response DTO:**
```json
{
  "id": "Guid",
  "ten": "string?",
  "khachHangId": "Guid",
  "ngayLap": "DateOnly",
  "giaTriDuKien": "decimal",
  "thoiGianDuKien": "DateOnly?",
  "phongBanPhuTrachChinhId": "long",
  "nguoiPhuTrachChinhId": "int",
  "nguoiTheoDoiId": "int",
  "giamDocId": "int",
  "giaVon": "decimal",
  "thanhTien": "decimal",
  "trangThaiId": "int",
  "hasHopDong": "bool",
  // Navigation display names
  "tenKhachHang": "string",
  "tenNguoiPhuTrach": "string",
  "tenNguoiTheoDoi": "string?",
  "tenGiamDoc": "string?",
  "tenTrangThai": "string?",
  "tenPhongBanPhuTrachChinh": "string?",
  // Junction data (IDs)
  "phongBanPhoiHopIds": ["long"],
  // Child collections (chi-tiet only)
  "phongBanPhoiHops": ["DuAnPhongBanPhoiHopDto"],
  "keHoachThuTiens": ["KeHoachThuTienDto"],
  "keHoachXuatHoaDons": ["KeHoachXuatHoaDonDto"]
}
```

**Child DTOs:**

```json
// DuAnPhongBanPhoiHopDto
{
  "phongBanId": "long",
  "tenPhongBan": "string?"
}

// KeHoachThuTienDto
{
  "id": "Guid",
  "loaiThanhToanId": "int",
  "tenLoaiThanhToan": "string?",
  "thoiGian": "DateOnly",
  "phanTram": "decimal",
  "giaTri": "decimal",
  "ghiChu": "string?"
}

// KeHoachXuatHoaDonDto
{
  "id": "Guid",
  "loaiThanhToanId": "int",
  "tenLoaiThanhToan": "string?",
  "thoiGian": "DateOnly",
  "phanTram": "decimal",
  "giaTri": "decimal",
  "ghiChu": "string?"
}
```

**Key Relationships:**
- `KhachHangId` → `KhachHang` (required)
- `PhongBanPhuTrachChinhId` → `DmDonVi` (legacy, use Join in query)
- `NguoiPhuTrachChinhId` → `DanhMucNguoiPhuTrach`
- `NguoiTheoDoiId` → `DanhMucNguoiTheoDoi`
- `GiamDocId` → `DanhMucGiamDoc`
- `TrangThaiId` → `DanhMucTrangThai`
- `PhongBanPhoiHopIds` → Junction table `DuAnPhongBanPhoiHop`

**Search Model (DuAnSearchModel):**
```json
{
  // Pagination (inherited from AggregateRootSearch)
  "pageNumber": "int",
  "pageSize": "int",

  // Full-text search (inherited from ISearchString)
  "searchString": "string?",        // Search in Ten

  // Filters
  "tuNgayDuKien": "DateOnly?",      // Filter by ThoiGianDuKien (from date)
  "denNgayDuKien": "DateOnly?",     // Filter by ThoiGianDuKien (to date)
  "giamDocId": "int?",              // Filter by GiamDoc
  "phongBanIds": ["long"],          // Filter by PhongBan (matches PhongBanPhuTrachChinhId OR PhongBanPhoiHops)
  "nguoiPhuTrachId": "int?",        // Filter by NguoiPhuTrachChinh
  "nguoiTheoDoiId": "int?"          // Filter by NguoiTheoDoi
}
```

**Filter notes:**
- `phongBanIds`: Array of department IDs. Matches if `PhongBanPhuTrachChinhId` OR any `PhongBanPhoiHops` contains the ID
- `tuNgayDuKien`/`denNgayDuKien`: Date range filter for expected completion date (`ThoiGianDuKien`)

---

## 11. Hợp đồng (HopDong)

**Base Route:** `hop-dong`
**Key Type:** `Guid`
**Type:** Full CRUD (no combobox)

| Phương thức | Đường dẫn                   | Mô tả                  | Request                          | Response                      |
| ----------- | --------------------------- | ---------------------- | -------------------------------- | ----------------------------- |
| POST        | `hop-dong/them-moi`         | Thêm mới hợp đồng      | `HopDongInsertModel`             | `HopDongDto`                  |
| PUT         | `hop-dong/cap-nhat/{id}`    | Cập nhật hợp đồng      | `HopDongUpdateModel`             | `HopDongDto`                  |
| GET         | `hop-dong/danh-sach`        | Danh sách hợp đồng     | `HopDongSearchModel` (query)     | `PaginatedList<HopDongDto>`   |
| GET         | `hop-dong/chi-tiet/{id}`    | Chi tiết hợp đồng      | -                                | `HopDongDto`                  |
| DELETE      | `hop-dong/xoa/{id}`         | Xóa hợp đồng           | -                                | `ResultApi`                   |

**Response DTO:**
```json
{
  "id": "Guid",
  "soHopDong": "string?",
  "ten": "string?",
  "duAnId": "Guid?",
  "khachHangId": "Guid",
  "ngayKy": "DateOnly",
  "soNgay": "int",
  "ngayNghiemThu": "DateOnly",
  "loaiHopDongId": "int",
  "trangThaiHopDongId": "int?",
  "nguoiPhuTrachChinhId": "int?",
  "nguoiTheoDoiId": "int?",
  "giamDocId": "int?",
  "giaTri": "decimal",
  "tienThue": "decimal?",
  "giaTriSauThue": "decimal?",
  "phongBanPhuTrachChinhId": "long?",
  "giaTriBaoLanh": "decimal",
  "ngayBaoLanhTu": "DateOnly?",
  "ngayBaoLanhDen": "DateOnly?",
  "thoiHanBaoHanh": "byte",
  "ngayBaoHanhTu": "DateOnly?",
  "ngayBaoHanhDen": "DateOnly?",
  "ghiChu": "string?",
  "tienDo": "string?",
  // Navigation display names
  "tenKhachHang": "string?",
  "tenDuAn": "string?",
  "tenLoaiHopDong": "string?",
  "tenTrangThai": "string?",
  "tenNguoiPhuTrach": "string?",
  "tenNguoiTheoDoi": "string?",
  "tenGiamDoc": "string?",
  "tenPhongBan": "string?",
  // Junction data (IDs)
  "phongBanPhoiHopIds": ["long"],
  // Child collections (chi-tiet only)
  "tepDinhKems": ["TepDinhKemDto"],
  "keHoachThuTiens": ["KeHoachThuTienHopDongDto"],
  "keHoachXuatHoaDons": ["KeHoachXuatHoaDonHopDongDto"],
  "thuTienThucTes": ["ThuTienThucTeDto"],
  "xuatHoaDonThucTes": ["XuatHoaDonThucTeDto"]
}
```

**Child DTOs:**

```json
// KeHoachThuTienHopDongDto
{
  "id": "Guid",
  "loaiThanhToanId": "int",
  "tenLoaiThanhToan": "string?",
  "thoiGian": "DateOnly",
  "phanTram": "decimal",
  "giaTri": "decimal",
  "ghiChu": "string?"
}

// KeHoachXuatHoaDonHopDongDto
{
  "id": "Guid",
  "loaiThanhToanId": "int",
  "tenLoaiThanhToan": "string?",
  "thoiGian": "DateOnly",
  "phanTram": "decimal",
  "giaTri": "decimal",
  "ghiChu": "string?"
}

// ThuTienThucTeDto
{
  "id": "Guid",
  "keHoachThuTienId": "Guid?",
  "loaiThanhToanId": "int",
  "tenLoaiThanhToan": "string?",
  "thoiGian": "DateOnly",
  "giaTri": "decimal",
  "ghiChu": "string?"
}

// XuatHoaDonThucTeDto
{
  "id": "Guid",
  "keHoachXuatHoaDonId": "Guid?",
  "loaiThanhToanId": "int",
  "tenLoaiThanhToan": "string?",
  "thoiGian": "DateOnly",
  "giaTri": "decimal",
  "soHoaDon": "string?",
  "kyHieuHoaDon": "string?",
  "ngayHoaDon": "DateOnly?",
  "ghiChu": "string?"
}
```

**Key Relationships:**
- `DuAnId` → `DuAn` (optional)
- `KhachHangId` → `KhachHang` (required)
- `LoaiHopDongId` → `DanhMucLoaiHopDong`
- `TrangThaiHopDongId` → `DanhMucTrangThai`
- `NguoiPhuTrachChinhId` → `DanhMucNguoiPhuTrach`
- `NguoiTheoDoiId` → `DanhMucNguoiTheoDoi`
- `GiamDocId` → `DanhMucGiamDoc`
- `PhongBanPhuTrachChinhId` → `DmDonVi` (legacy, use Join in query)
- `PhongBanPhoiHopIds` → Junction table `HopDongPhongBanPhoiHop`

**Search Model (HopDongSearchModel):**
```json
{
  // Pagination (inherited from AggregateRootSearch)
  "pageNumber": "int",
  "pageSize": "int",

  // Full-text search (inherited from ISearchString)
  "searchString": "string?"       // Search in SoHopDong, Ten
}
```

**Note:** HopDong only supports basic search. No additional filters beyond pagination and full-text search.

---

## 12. Công việc (CongViec) ✨ NEW in v0.0.2

**Base Route:** `cong-viec`
**Key Type:** `Guid`
**Type:** Full CRUD (no combobox)

| Phương thức | Đường dẫn                  | Mô tả                | Request                         | Response                      |
| ----------- | -------------------------- | -------------------- | ------------------------------- | ----------------------------- |
| POST        | `cong-viec/them-moi`       | Thêm mới công việc   | `CongViecInsertModel`           | `CongViecDto`                 |
| PUT         | `cong-viec/cap-nhat/{id}`  | Cập nhật công việc   | `CongViecUpdateModel`           | `CongViecDto`                 |
| GET         | `cong-viec/danh-sach`      | Danh sách công việc  | `CongViecSearchModel` (query)   | `PaginatedList<CongViecDto>`  |
| GET         | `cong-viec/chi-tiet/{id}`  | Chi tiết công việc   | -                               | `CongViecDto`                 |
| DELETE      | `cong-viec/xoa/{id}`       | Xóa công việc        | -                               | `ResultApi`                   |

**Response DTO:**
```json
{
  "id": "Guid",
  "duAnId": "Guid",
  "thoiGian": "MonthYear",        // MM-yyyy format
  "userPortalId": "long",
  "nguoiThucHien": "string",
  "donViId": "long",
  "tenDonVi": "string",
  "phongBanId": "long?",
  "tenPhongBan": "string?",
  "keHoachCongViec": "string",    // Max 2000 chars
  "ngayHoanThanh": "DateOnly?",
  "thucTe": "string?",            // Max 2000 chars
  "trangThaiId": "int",
  "tenTrangThai": "string",
  // Navigation display names
  "tenDuAn": "string?"
}
```

**Search Model:**
```json
{
  "duAnId": "Guid",              // Required - Filter by project
  "searchString": "string?",     // Search in NguoiThucHien, KeHoachCongViec, ThucTe
  "pageNumber": "int",
  "pageSize": "int"
}
```

**Insert Model:**
```json
{
  "duAnId": "Guid",              // Required
  "thoiGian": "MonthYear",       // MM-yyyy format
  "userPortalId": "long",        // Required - FK to USER_MASTER
  "donViId": "long",             // Required - FK to DM_DONVI
  "phongBanId": "long?",         // Optional - FK to DM_DONVI
  "keHoachCongViec": "string",   // Max 2000 chars
  "ngayHoanThanh": "DateOnly?",
  "thucTe": "string?",           // Max 2000 chars
  "trangThaiId": "int"           // Required
}
```

**Key Relationships:**
- `DuAnId` → `DuAn` (required)
- `UserPortalId` → `USER_MASTER` (legacy, use Join in query)
- `DonViId` → `DM_DONVI` (legacy, use Join in query)
- `PhongBanId` → `DM_DONVI` (legacy, use Join in query)
- `TrangThaiId` → `DanhMucTrangThai`

**Notes:**
- `danh-sach` endpoint requires `duAnId` filter (no global list)
- Uses `MonthYear` value type for `ThoiGian` property
- Legacy FKs (`UserPortalId`, `DonViId`, `PhongBanId`) should use `.Join()` in queries, not navigation properties

---

# Part C: Legacy/Reference

## 13. Danh mục đơn vị (DanhMucDonVi) - Legacy

**Base Route:** `danh-muc-don-vi`
**Key Type:** `long`
**Type:** Read-only (Legacy table `DM_DONVI`)

| Phương thức | Đường dẫn                              | Mô tả                     | Request | Response                      |
| ----------- | -------------------------------------- | ------------------------- | ------- | ----------------------------- |
| GET         | `danh-muc-don-vi/combobox`             | Danh sách combobox        | -       | `List<ComboBoxDto<long>>`     |
| GET         | `danh-muc-don-vi/danh-sach/phong-ban`  | Danh sách phòng ban       | -       | `List<DanhMucDonViDto>`       |
| GET         | `danh-muc-don-vi/danh-sach/don-vi`     | Danh sách đơn vị          | -       | `List<DanhMucDonViDto>`       |

**Response DTO:**
```json
{
  "id": "long",
  "maDonVi": "string?",
  "tenDonVi": "string?",
  "tenVietTat": "string?",
  "donViCapChaId": "long?",
  "tenDonViCapCha": "string?"
}
```

**Note:** Legacy table managed outside EF Core migrations. No navigation properties allowed.

---

## 14. Người dùng (NguoiDung) - Legacy

**Base Route:** `nguoi-dung`
**Key Type:** `long`
**Type:** Read-only (Legacy table `USER_MASTER`)

| Phương thức | Đường dẫn                | Mô tả                       | Request                                  | Response                    |
| ----------- | ------------------------ | --------------------------- | ---------------------------------------- | --------------------------- |
| GET         | `nguoi-dung/combobox`    | Danh sách combobox          | `donViId`, `phongBanId` (query)          | `List<ComboBoxDto<long>>`   |
| GET         | `nguoi-dung/danh-sach`   | Danh sách người dùng        | `donViId?`, `phongBanId?` (query)        | `List<NguoiDungDto>`        |

**Response DTO:**
```json
{
  "id": "long",
  "userName": "string?",
  "hoTen": "string?",
  "donViId": "long?",
  "tenDonVi": "string?",
  "phongBanId": "long?",
  "tenPhongBan": "string?"
}
```

**Note:** Legacy table managed outside EF Core migrations. No navigation properties allowed.

---

# Summary

## API Pattern Summary

### Full CRUD (6 endpoint)

| Hành động | Phương thức | Mẫu đường dẫn          |
| --------- | ----------- | ---------------------- |
| Thêm mới  | POST        | `{base}/them-moi`      |
| Cập nhật  | PUT         | `{base}/cap-nhat/{id}` |
| Danh sách | GET         | `{base}/danh-sach`     |
| Chi tiết  | GET         | `{base}/chi-tiet/{id}` |
| Combobox  | GET         | `{base}/combobox`      |
| Xóa       | DELETE      | `{base}/xoa/{id}`      |

### Full CRUD (5 endpoint - no combobox)

| Hành động | Phương thức | Mẫu đường dẫn          |
| --------- | ----------- | ---------------------- |
| Thêm mới  | POST        | `{base}/them-moi`      |
| Cập nhật  | PUT         | `{base}/cap-nhat/{id}` |
| Danh sách | GET         | `{base}/danh-sach`     |
| Chi tiết  | GET         | `{base}/chi-tiet/{id}` |
| Xóa       | DELETE      | `{base}/xoa/{id}`      |

### Read-only (2-3 endpoint)

| Hành động | Phương thức | Mẫu đường dẫn       |
| --------- | ----------- | ------------------- |
| Danh sách | GET         | `{base}/danh-sach`  |
| Combobox  | GET         | `{base}/combobox`   |

---

## Controller Types

| Type          | Controllers                           | Notes                              |
| ------------- | ------------------------------------- | ---------------------------------- |
| **Full CRUD (6)** | DanhMucGiamDoc, DanhMucNguoiPhuTrach, DanhMucNguoiTheoDoi, DanhMucLoaiTrangThai, DanhMucTrangThai, DanhMucLoaiHopDong, DanhMucLoaiThanhToan, DoanhNghiep, KhachHang | Full Create/Read/Update/Delete + Combobox |
| **Full CRUD (5)** | DuAn, HopDong, CongViec | No combobox endpoint |
| **Read-only** | DanhMucDonVi, NguoiDung               | Legacy tables, no write operations |

---

## Mapping Key Types

| Controller                | Key Type | FE TypeScript Type | Type       |
| ------------------------- | -------- | ------------------ | ---------- |
| DanhMucGiamDoc            | `Guid`   | `string`           | Full CRUD  |
| DanhMucNguoiPhuTrach      | `Guid`   | `string`           | Full CRUD  |
| DanhMucNguoiTheoDoi       | `Guid`   | `string`           | Full CRUD  |
| DanhMucLoaiTrangThai      | `int`    | `number`           | Full CRUD  |
| DanhMucTrangThai          | `int`    | `number`           | Full CRUD  |
| DanhMucLoaiHopDong        | `int`    | `number`           | Full CRUD  |
| DanhMucLoaiThanhToan      | `int`    | `number`           | Full CRUD  |
| DanhMucDonVi              | `long`   | `number`           | Read-only  |
| NguoiDung                 | `long`   | `number`           | Read-only  |
| DoanhNghiep               | `Guid`   | `string`           | Full CRUD  |
| KhachHang                 | `Guid`   | `string`           | Full CRUD  |
| DuAn                      | `Guid`   | `string`           | Full CRUD  |
| HopDong                   | `Guid`   | `string`           | Full CRUD  |
| CongViec                  | `Guid`   | `string`           | Full CRUD  |

---

## Common Response Wrapper

Tất cả API trả về dưới dạng `ResultApi<T>`:

```json
{
  "result": true,
  "errorMessage": "",
  "dataResult": { ... }
}
```

**Fields:**
- `result`: `bool` - Trạng thái thành công/thất bại
- `errorMessage`: `string?` - Thông báo lỗi (nếu có)
- `dataResult`: `T?` - Dữ liệu trả về

---

## Notes

1. **Phân trang**: Endpoint `danh-sach` trả về `PaginatedList<T>` với cấu trúc:
   ```json
   {
     "data": [...],
     "totalRows": 0,
     "pageNumber": 1,
     "totalPages": 0,
     "hasPreviousPage": false,
     "hasNextPage": true,
     "statistic": null
   }
   ```

   **Fields:**
   - `data`: `List<T>` - Danh sách dữ liệu
   - `totalRows`: `int` - Tổng số dòng
   - `pageNumber`: `int` - Vị trí trang hiện tại
   - `totalPages`: `int` - Tổng số trang
   - `hasPreviousPage`: `bool` - Có trang trước không
   - `hasNextPage`: `bool` - Có trang tiếp theo không
   - `statistic`: `object?` - Thống kê tổng hợp (optional)

2. **Combobox**: Trả về `List<ComboBoxDto<TKey>>`:
   ```json
   [
     { "Id": "id", "Ten": "Tên hiển thị", "Ma": "Mã" }
   ]
   ```

3. **Filter combobox**:
   - `DanhMucTrangThai`: hỗ trợ lọc theo `loaiTrangThaiId`
   - `DoanhNghiep`: hỗ trợ tìm kiếm theo `search`
   - `NguoiDung`: hỗ trợ lọc theo `donViId`, `phongBanId`

4. **Legacy tables** (`DanhMucDonVi`, `NguoiDung`):
   - Read-only, không có CRUD
   - Không tạo navigation properties (FK) đến các bảng này
   - Sử dụng `.Join()` extension method trong queries (không dùng Include)

5. **Junction entities** (`DuAn`, `HopDong`):
   - `PhongBanPhoiHopIds`: List ID phòng ban phối hợp (many-to-many)
   - Junction tables: `DuAnPhongBanPhoiHop`, `HopDongPhongBanPhoiHop`
   - `chi-tiet/{id}` endpoint returns child collections

6. **Child collections** (trả về trong `chi-tiet/{id}`):
   - **DuAn**: `phongBanPhoiHops`, `keHoachThuTiens`, `keHoachXuatHoaDons`
   - **HopDong**: `tepDinhKems`, `keHoachThuTiens`, `keHoachXuatHoaDons`, `thuTienThucTes`, `xuatHoaDonThucTes`

7. **CongViec** (new in v0.0.2):
   - Requires `DuAnId` filter in `danh-sach` endpoint (no global list)
   - Uses `MonthYear` value type for `ThoiGian` property
   - Legacy FKs require `.Join()` in queries, not navigation properties

---