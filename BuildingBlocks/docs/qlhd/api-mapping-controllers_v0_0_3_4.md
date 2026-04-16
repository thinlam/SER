# QLHD WebAPI - FE API Mapping Report

**Generated:** 2026-03-27
**Module:** Quản lý hợp đồng (QLHD)
**Base URL:** `/api/qlhd/`

---

## Version History

| Version | Date       | Changes                                                    |
| ------- | ---------- | ---------------------------------------------------------- |
| v0.0.1  | 2026-03-25 | Initial documentation                                      |
| v0.0.2  | 2026-03-26 | Add CongViec entity (Full CRUD)                            |
| v0.0.3  | 2026-03-27 | Add TienDo, BaoCaoTienDo, KhoKhanVuongMac entities (Quản lý tiến độ) |
| v0.0.4  | 2026-03-27 | Add ThuTien entity (Quản lý thu tiền - Kế hoạch & Thực tế) |

---

## Thay đổi v0.0.4 -> v0.0.3 (Dành cho Frontend)

### Tom tat

| Loai thay doi       | Chi tiet                                                  |
| ------------------- | --------------------------------------------------------- |
| **API moi**         | 5 endpoint cho ThuTien entity moi                         |
| **Breaking changes** | Khong                                                     |
| **Backward compatible** | Co                                                      |

### API Moi: Quan ly thu tien (Payment Management)

Entity moi de quan ly thu tien hop dong:

| Entity             | Vietnamese                    | Parent      | Endpoints |
| ------------------ | ----------------------------- | ----------- | --------- |
| `ThuTien`          | Thu tien (Ke hoach + Thuc te) | HopDong     | 5         |

### Entity Relationships

```
HopDong (1) ---- (N) KeHoachThuTien
     |                   |
     |                   +---- (0..1) ThuTienThucTe
     |
     +--------- (N) ThuTienThucTe
```

### Endpoints moi can tich hop:

#### ThuTien Controller (5 endpoints)

| Method | Endpoint                                  | Mo ta                              | FE Action             |
| ------ | ----------------------------------------- | ---------------------------------- | --------------------- |
| `GET`  | `/api/qlhd/thu-tien/danh-sach`            | DS hop dong co ke hoach thu tien   | Bang danh sach HD     |
| `GET`  | `/api/qlhd/thu-tien/{hopDongId}/danh-sach`| DS ke hoach + thuc te theo HD      | Bang ke hoach thu tien|
| `POST` | `/api/qlhd/thu-tien/luu`                  | Them/sua ke hoach + thuc te        | Form nhap lieu        |
| `GET`  | `/api/qlhd/thu-tien/chi-tiet`             | Chi tiet ke hoach + thuc te        | Trang chi tiet        |
| `DELETE`| `/api/qlhd/thu-tien/xoa/{id}`            | Xoa thuc te (cascade ke hoach)     | Button xoa            |

---

## Thay đổi v0.0.3 -> v0.0.2 (Dành cho Frontend)

### Tom tat

| Loai thay doi       | Chi tiet                                                  |
| ------------------- | --------------------------------------------------------- |
| **API moi**         | 17 endpoint cho 3 entity moi                              |
| **Breaking changes** | Khong                                                     |
| **Backward compatible** | Co                                                      |

### API Moi: Quan ly tien do (Progress Management)

3 entity moi de quan ly tien do hop dong:

| Entity             | Vietnamese            | Parent      | Endpoints |
| ------------------ | --------------------- | ----------- | --------- |
| `TienDo`           | Tien do / Giai doan   | HopDong     | 5         |
| `BaoCaoTienDo`     | Bao cao tien do       | TienDo      | 7         |
| `KhoKhanVuongMac`  | Kho khan vuong mac    | HopDong     | 5         |

### Entity Relationships

```
HopDong (1) ---- (N) TienDo
     |                 |
     |                 +---- (N) BaoCaoTienDo
     |
     +--------- (N) KhoKhanVuongMac
                         |
                         +---- (Optional) TienDo
```

### Endpoints moi can tich hop:

#### TienDo Controller (5 endpoints)

| Method | Endpoint                                  | Mo ta                     | FE Action            |
| ------ | ----------------------------------------- | ------------------------- | -------------------- |
| `POST` | `/api/qlhd/tien-do/them-moi`              | Tao tien do moi           | Form tao tien do     |
| `PUT`  | `/api/qlhd/tien-do/cap-nhat/{id}`         | Cap nhat tien do          | Form sua tien do     |
| `GET`  | `/api/qlhd/tien-do/danh-sach?hopDongId=`  | DS tien do theo hop dong  | Bang danh sach TD    |
| `GET`  | `/api/qlhd/tien-do/chi-tiet/{id}`         | Chi tiet tien do          | Trang chi tiet TD    |
| `DELETE`| `/api/qlhd/tien-do/xoa/{id}`             | Xoa tien do               | Button xoa TD        |

#### BaoCaoTienDo Controller (7 endpoints)

| Method | Endpoint                                        | Mo ta                       | FE Action               |
| ------ | ----------------------------------------------- | --------------------------- | ----------------------- |
| `POST` | `/api/qlhd/bao-cao-tien-do/them-moi`            | Tao bao cao moi             | Form tao bao cao        |
| `PUT`  | `/api/qlhd/bao-cao-tien-do/cap-nhat/{id}`       | Cap nhat bao cao            | Form sua bao cao        |
| `GET`  | `/api/qlhd/bao-cao-tien-do/danh-sach?tienDoId=` | DS bao cao theo tien do     | Bang danh sach BC       |
| `GET`  | `/api/qlhd/bao-cao-tien-do/chi-tiet/{id}`       | Chi tiet bao cao            | Trang chi tiet BC       |
| `DELETE`| `/api/qlhd/bao-cao-tien-do/xoa/{id}`           | Xoa bao cao                 | Button xoa BC           |
| `GET`  | `/api/qlhd/bao-cao-tien-do/cho-duyet?nguoiDuyetId=` | DS bao cao cho duyet   | Danh sach cho duyet     |
| `POST` | `/api/qlhd/bao-cao-tien-do/duyet/{id}`          | Duyet/tu choi bao cao       | Button duyet/tu choi    |

#### KhoKhanVuongMac Controller (5 endpoints)

| Method | Endpoint                                            | Mo ta                      | FE Action             |
| ------ | --------------------------------------------------- | -------------------------- | --------------------- |
| `POST` | `/api/qlhd/kho-khan-vuong-mac/them-moi`             | Tao kho khan moi           | Form tao KKVM         |
| `PUT`  | `/api/qlhd/kho-khan-vuong-mac/cap-nhat/{id}`        | Cap nhat kho khan          | Form sua KKVM         |
| `GET`  | `/api/qlhd/kho-khan-vuong-mac/danh-sach?hopDongId=` | DS kho khan theo hop dong  | Bang danh sach KKVM   |
| `GET`  | `/api/qlhd/kho-khan-vuong-mac/chi-tiet/{id}`        | Chi tiet kho khan          | Trang chi tiet KKVM   |
| `DELETE`| `/api/qlhd/kho-khan-vuong-mac/xoa/{id}`            | Xoa kho khan               | Button xoa KKVM       |

---

## Luu y quan trong cho FE:

### 1. ThuTien - Upsert Pattern

ThuTien su dung upsert pattern (khong co endpoint them-moi va cap-nhat rieng biet):

```typescript
// Luu - Tu dong xac dinh insert hay update
POST /api/qlhd/thu-tien/luu
{
  "hopDongId": "guid",           // Required
  "id": null,                    // null -> insert moi
  // hoac
  "id": "guid",                  // co gia tri -> update
  ...
}

// Lay chi tiet - Su dung query params
GET /api/qlhd/thu-tien/chi-tiet?thuTienThucTeId=abc
// hoac
GET /api/qlhd/thu-tien/chi-tiet?keHoachThuTienId=abc
```

### 2. TienDo - Phai filter theo HopDong

```typescript
// Sai - se khong tra ve du lieu
GET /api/qlhd/tien-do/danh-sach

// Dung - phai co hopDongId
GET /api/qlhd/tien-do/danh-sach?hopDongId=abc-123-...
```

### 3. BaoCaoTienDo - Phai filter theo TienDo

```typescript
// Dung - phai co tienDoId
GET /api/qlhd/bao-cao-tien-do/danh-sach?tienDoId=abc-123-...
```

### 4. KhoKhanVuongMac - Phai filter theo HopDong

```typescript
// Dung - phai co hopDongId
GET /api/qlhd/kho-khan-vuong-mac/danh-sach?hopDongId=abc-123-...
```

### 5. BaoCaoTienDo Approval Workflow

Bao cao tien do co the co luong duyet:

```typescript
// Tao bao cao can duyet
{
  "tienDoId": "guid",
  "ngayBaoCao": "2026-03-27",
  "canDuyet": true,           // Bat luong duyet
  "nguoiDuyetId": 123,        // ID nguoi duyet
  "tenNguoiDuyet": "Nguyen Van A"
}

// Lay danh sach cho duyet theo nguoi duyet
GET /api/qlhd/bao-cao-tien-do/cho-duyet?nguoiDuyetId=123

// Duyet bao cao
POST /api/qlhd/bao-cao-tien-do/duyet/{id}
{
  "nguoiDuyetId": 123,
  "tenNguoiDuyet": "Nguyen Van A",
  "duyet": true    // true = duyet, false = tu choi
}
```

---

## TypeScript Interfaces cho FE:

### ThuTien Types (v0.0.4)

```typescript
// types/thu-tien.ts

// MonthYear value type
interface MonthYear {
  month: number;   // 1-12
  year: number;    // e.g. 2026
}

// Hop dong co ke hoach thu tien
interface HopDongCoKeHoachDto {
  id: string;
  soHopDong?: string;
  ten?: string;
  duAnId?: string;
  tenDuAn?: string;
  khachHangId: string;
  tenKhachHang?: string;
  giaTri: number;
  trangThaiId?: number;
  tenTrangThai?: string;
}

// Ke hoach thu tien voi thuc te
interface KeHoachThuTienWithThucTeDto {
  keHoachId: string;
  loaiThanhToanId: number;
  tenLoaiThanhToan?: string;
  thoiGianKeHoach: MonthYear;
  phanTram: number;
  giaTriKeHoach: number;
  ghiChuKeHoach?: string;
  // Thuc te (nullable)
  thucTeId?: string;
  thoiGianThucTe?: string;     // DateOnly: "yyyy-MM-dd"
  giaTriThucTe?: number;
  ghiChuThucTe?: string;
  hasThucTe: boolean;
}

// Insert/Update model
interface ThuTienInsertModel {
  hopDongId: string;           // Required
  id?: string;                 // null -> insert, has value -> update
  // Ke hoach
  loaiThanhToanId: number;     // Required
  thoiGianKeHoach: MonthYear;  // Required
  phanTramKeHoach: number;     // Required
  giaTriKeHoach?: number;
  ghiChuKeHoach?: string;
  // Thuc te
  thoiGianThucTe?: MonthYear;
  giaTriThucTe?: number;
  ghiChuThucTe?: string;
  // Hoa don
  soHoaDon?: string;
  kyHieuHoaDon?: string;
  ngayHoaDon?: string;         // DateOnly: "yyyy-MM-dd"
}

// Chi tiet DTO
interface ThuTienChiTietDto {
  keHoach?: KeHoachThuTienChiTietDto;
  thucTe?: ThuTienThucTeChiTietDto;
  thongTinChung?: ThongTinChungDto;
}

interface KeHoachThuTienChiTietDto {
  id: string;
  duAnId: string;
  loaiThanhToanId: number;
  thoiGian: MonthYear;
  phanTram: number;
  giaTri: number;
  ghiChu?: string;
}

interface ThuTienThucTeChiTietDto {
  id: string;
  hopDongId: string;
  loaiThanhToanId: number;
  thoiGian: string;            // DateOnly: "yyyy-MM-dd"
  giaTri: number;
  ghiChu?: string;
}

interface ThongTinChungDto {
  tenHopDong?: string;
  soHopDong?: string;
  tenDuAn?: string;
  tenLoaiThanhToan?: string;
}

// Search model
interface ThuTienSearchModel {
  hopDongId?: string;
  loaiThanhToanId?: number;
  duAnId?: string;
  tuNgayKeHoach?: string;      // DateOnly
  denNgayKeHoach?: string;
  tuNgayHopDong?: string;
  denNgayHopDong?: string;
  nguoiTheoDoiId?: number;
  nguoiPhuTrachChinhId?: number;
  giamDocId?: number;
  trangThaiId?: number;
  searchString?: string;
  pageNumber?: number;
  pageSize?: number;
}
```

### TienDo Types

```typescript
// types/tien-do.ts

interface TienDoDto {
  id: string;
  hopDongId: string;
  ten: string;                    // Max 500 chars
  phanTramKeHoach: number;        // 0-100
  ngayBatDauKeHoach?: string;     // DateOnly: "yyyy-MM-dd"
  ngayKetThucKeHoach?: string;    // DateOnly: "yyyy-MM-dd"
  moTa?: string;                  // Max 2000 chars
  trangThaiId: number;
  tenTrangThai?: string;
  // Denormalized fields
  phanTramThucTe: number;         // Updated from BaoCaoTienDo
  ngayCapNhatGanNhat?: string;    // Updated from BaoCaoTienDo
}

interface TienDoInsertModel {
  hopDongId: string;              // Required
  ten: string;                    // Required, max 500 chars
  phanTramKeHoach?: number;       // 0-100
  ngayBatDauKeHoach?: string;     // "yyyy-MM-dd"
  ngayKetThucKeHoach?: string;    // "yyyy-MM-dd"
  moTa?: string;                  // Max 2000 chars
  trangThaiId?: number;
}

interface TienDoUpdateModel {
  ten: string;
  phanTramKeHoach?: number;
  ngayBatDauKeHoach?: string;
  ngayKetThucKeHoach?: string;
  moTa?: string;
  trangThaiId?: number;
}
```

### BaoCaoTienDo Types

```typescript
// types/bao-cao-tien-do.ts

interface BaoCaoTienDoDto {
  id: string;
  tienDoId: string;
  tenTienDo?: string;
  ngayBaoCao: string;             // DateOnly: "yyyy-MM-dd"
  nguoiBaoCaoId: number;
  tenNguoiBaoCao: string;
  phanTramThucTe: number;         // 0-100
  noiDungDaLam?: string;          // Max 4000 chars
  keHoachTiepTheo?: string;       // Max 4000 chars
  ghiChu?: string;                // Max 2000 chars
  // Approval fields
  canDuyet: boolean;
  daDuyet: boolean;
  nguoiDuyetId?: number;
  tenNguoiDuyet?: string;
  ngayDuyet?: string;
  trangThaiDuyet: string;         // Computed: "Khong can duyet" | "Da duyet" | "Cho duyet"
}

interface BaoCaoTienDoInsertModel {
  tienDoId: string;               // Required
  ngayBaoCao: string;             // Required, "yyyy-MM-dd"
  nguoiBaoCaoId?: number;
  tenNguoiBaoCao?: string;        // Max 200 chars
  phanTramThucTe?: number;        // 0-100
  noiDungDaLam?: string;          // Max 4000 chars
  keHoachTiepTheo?: string;       // Max 4000 chars
  ghiChu?: string;                // Max 2000 chars
  canDuyet: boolean;
  nguoiDuyetId?: number;          // Required if canDuyet = true
  tenNguoiDuyet?: string;         // Required if canDuyet = true
}

interface BaoCaoTienDoDuyetModel {
  nguoiDuyetId: number;
  tenNguoiDuyet: string;
  duyet: boolean;                 // true = approve, false = reject
}
```

### KhoKhanVuongMac Types

```typescript
// types/kho-khan-vuong-mac.ts

interface KhoKhanVuongMacDto {
  id: string;
  hopDongId: string;
  tienDoId?: string;              // Optional link to TienDo
  tenTienDo?: string;
  noiDung: string;                // Max 2000 chars
  mucDo?: string;                 // "Nhe", "Trung binh", "Nang"
  ngayPhatHien: string;           // DateOnly: "yyyy-MM-dd"
  ngayGiaiQuyet?: string;         // DateOnly: "yyyy-MM-dd"
  bienPhapKhacPhuc?: string;      // Max 2000 chars
  trangThaiId: number;
  tenTrangThai?: string;
}

interface KhoKhanVuongMacInsertModel {
  hopDongId: string;              // Required
  tienDoId?: string;              // Optional
  noiDung: string;                // Required, max 2000 chars
  mucDo?: string;                 // Max 50 chars
  ngayPhatHien: string;           // Required, "yyyy-MM-dd"
  ngayGiaiQuyet?: string;         // "yyyy-MM-dd"
  bienPhapKhacPhuc?: string;      // Max 2000 chars
  trangThaiId?: number;
}
```

---

## API Service Examples:

### ThuTien Service (v0.0.4)

```typescript
// services/thu-tien.service.ts

const BASE_URL = '/api/qlhd/thu-tien';

export const thuTienApi = {
  // Lay danh sach hop dong co ke hoach thu tien (paginated)
  getList: (searchModel: ThuTienSearchModel) =>
    axios.get<PaginatedList<HopDongCoKeHoachDto>>(`${BASE_URL}/danh-sach`, {
      params: searchModel
    }),

  // Lay danh sach ke hoach + thuc te theo hop dong
  getByHopDong: (hopDongId: string) =>
    axios.get<List<KeHoachThuTienWithThucTeDto>>(`${BASE_URL}/${hopDongId}/danh-sach`),

  // Luu (insert/update) ke hoach + thuc te
  save: (model: ThuTienInsertModel) =>
    axios.post<ThuTienChiTietDto>(`${BASE_URL}/luu`, model),

  // Lay chi tiet
  getDetail: (params: { thuTienThucTeId?: string; keHoachThuTienId?: string }) =>
    axios.get<ThuTienChiTietDto>(`${BASE_URL}/chi-tiet`, { params }),

  // Xoa (cascade: xoa thuc te + ke hoach)
  delete: (id: string) =>
    axios.delete(`${BASE_URL}/xoa/${id}`),
};
```

### TienDo Service

```typescript
// services/tien-do.service.ts

const BASE_URL = '/api/qlhd/tien-do';

export const tienDoApi = {
  // Lay danh sach - PHAI co hopDongId
  getList: (hopDongId: string) =>
    axios.get<List<TienDoDto>>(`${BASE_URL}/danh-sach`, {
      params: { hopDongId }
    }),

  // Lay chi tiet
  getById: (id: string) =>
    axios.get<TienDoDto>(`${BASE_URL}/chi-tiet/${id}`),

  // Tao moi
  create: (model: TienDoInsertModel) =>
    axios.post<TienDoDto>(`${BASE_URL}/them-moi`, model),

  // Cap nhat
  update: (id: string, model: TienDoUpdateModel) =>
    axios.put<TienDoDto>(`${BASE_URL}/cap-nhat/${id}`, model),

  // Xoa
  delete: (id: string) =>
    axios.delete(`${BASE_URL}/xoa/${id}`),
};
```

```typescript
// services/bao-cao-tien-do.service.ts

const BASE_URL = '/api/qlhd/bao-cao-tien-do';

export const baoCaoTienDoApi = {
  // Lay danh sach - PHAI co tienDoId
  getList: (tienDoId: string) =>
    axios.get<List<BaoCaoTienDoDto>>(`${BASE_URL}/danh-sach`, {
      params: { tienDoId }
    }),

  // Lay danh sach cho duyet
  getPending: (nguoiDuyetId: number) =>
    axios.get<List<BaoCaoTienDoDto>>(`${BASE_URL}/cho-duyet`, {
      params: { nguoiDuyetId }
    }),

  // Duyet bao cao
  approve: (id: string, model: BaoCaoTienDoDuyetModel) =>
    axios.post<BaoCaoTienDoDto>(`${BASE_URL}/duyet/${id}`, model),

  // CRUD operations...
  getById: (id: string) =>
    axios.get<BaoCaoTienDoDto>(`${BASE_URL}/chi-tiet/${id}`),
  create: (model: BaoCaoTienDoInsertModel) =>
    axios.post<BaoCaoTienDoDto>(`${BASE_URL}/them-moi`, model),
  update: (id: string, model: BaoCaoTienDoUpdateModel) =>
    axios.put<BaoCaoTienDoDto>(`${BASE_URL}/cap-nhat/${id}`, model),
  delete: (id: string) =>
    axios.delete(`${BASE_URL}/xoa/${id}`),
};
```

---

## So sanh so luong API

| Version | Controllers | Endpoints |
| ------- | ----------- | --------- |
| v0.0.1  | 13          | ~65       |
| v0.0.2  | 14 (+1)     | ~70 (+5)  |
| v0.0.3  | 17 (+3)     | ~87 (+17) |
| v0.0.4  | 18 (+1)     | ~92 (+5)  |

---

## Khong co Breaking Changes

Tat ca API v0.0.2 va truoc do van hoat dong binh thuong. FE chi can them tich hop cho TienDo, BaoCaoTienDo, KhoKhanVuongMac neu can.

---

## Table of Contents

1. [Danh muc (Master Data)](#part-a-danh-muc-master-data)
2. [Business Entities](#part-b-business-entities)
   - [ThuTien (Moi v0.0.4)](#thu-tien-thutien)
   - [TienDo (Moi v0.0.3)](#tien-do-tiendo)
   - [BaoCaoTienDo (Moi v0.0.3)](#bao-cao-tien-do-baocaotiendo)
   - [KhoKhanVuongMac (Moi v0.0.3)](#kho-khan-vuong-mac-khokhanvuongmac)
3. [Legacy/Reference](#part-c-legacyreference)

---

# Part A: Danh muc (Master Data)

> Xem chi tiet tai `api-mapping-controllers_v0_0_2.md`

---

# Part B: Business Entities

## ThuTien (thu-tien)

**Base Route:** `thu-tien`
**Key Type:** `Guid`
**Type:** Upsert Pattern (insert + update qua 1 endpoint)

| Phuong thuc | Duong dan                           | Mo ta                              | Request                   | Response                        |
| ----------- | ----------------------------------- | ---------------------------------- | ------------------------- | ------------------------------- |
| GET         | `thu-tien/danh-sach`                | DS hop dong co ke hoach thu tien   | `ThuTienSearchModel`      | `PaginatedList<HopDongCoKeHoachDto>` |
| GET         | `thu-tien/{hopDongId}/danh-sach`    | DS ke hoach + thuc te theo hop dong| `hopDongId` (route)       | `List<KeHoachThuTienWithThucTeDto>` |
| POST        | `thu-tien/luu`                      | Luu ke hoach + thuc te (upsert)    | `ThuTienInsertModel`      | `ThuTienChiTietDto`             |
| GET         | `thu-tien/chi-tiet`                 | Chi tiet ke hoach + thuc te        | `thuTienThucTeId` or `keHoachThuTienId` (query) | `ThuTienChiTietDto` |
| DELETE      | `thu-tien/xoa/{id}`                 | Xoa thuc te (cascade ke hoach)     | `id` (route)              | `ResultApi`                     |

**Response DTO - KeHoachThuTienWithThucTeDto:**
```json
{
  "keHoachId": "Guid",
  "loaiThanhToanId": 0,
  "tenLoaiThanhToan": "string?",
  "thoiGianKeHoach": { "month": 1, "year": 2026 },
  "phanTram": 0,
  "giaTriKeHoach": 0,
  "ghiChuKeHoach": "string?",
  "thucTeId": "Guid?",
  "thoiGianThucTe": "DateOnly?",
  "giaTriThucTe": 0,
  "ghiChuThucTe": "string?",
  "hasThucTe": false
}
```

**Insert Model:**
```json
{
  "hopDongId": "Guid (required)",
  "id": "Guid? (null -> insert, has value -> update)",
  "loaiThanhToanId": 0,
  "thoiGianKeHoach": { "month": 1, "year": 2026 },
  "phanTramKeHoach": 0,
  "giaTriKeHoach": 0,
  "ghiChuKeHoach": "string?",
  "thoiGianThucTe": { "month": 1, "year": 2026 },
  "giaTriThucTe": 0,
  "ghiChuThucTe": "string?",
  "soHoaDon": "string?",
  "kyHieuHoaDon": "string?",
  "ngayHoaDon": "DateOnly?"
}
```

**Search Model:**
```json
{
  "hopDongId": "Guid?",
  "loaiThanhToanId": 0,
  "duAnId": "Guid?",
  "tuNgayKeHoach": "DateOnly?",
  "denNgayKeHoach": "DateOnly?",
  "tuNgayHopDong": "DateOnly?",
  "denNgayHopDong": "DateOnly?",
  "nguoiTheoDoiId": 0,
  "nguoiPhuTrachChinhId": 0,
  "giamDocId": 0,
  "trangThaiId": 0,
  "searchString": "string?",
  "pageNumber": 1,
  "pageSize": 10
}
```

**Luu y:**
- Endpoint `thu-tien/luu` su dung upsert pattern: `id` null -> insert, `id` co gia tri -> update
- Xoa thuc te se tu dong xoa ke hoach (cascade)
- `thoiGianKeHoach` va `thoiGianThucTe` la `MonthYear` value type (month: 1-12, year: number)

---

## TienDo (tien-do)

**Base Route:** `tien-do`
**Key Type:** `Guid`
**Type:** Full CRUD (filter by HopDong)

| Phuong thuc | Duong dan                      | Mo ta                     | Request             | Response            |
| ----------- | ------------------------------ | ------------------------- | ------------------- | ------------------- |
| POST        | `tien-do/them-moi`             | Them moi tien do          | `TienDoInsertModel` | `TienDoDto`         |
| PUT         | `tien-do/cap-nhat/{id}`        | Cap nhat tien do          | `TienDoUpdateModel` | `TienDoDto`         |
| GET         | `tien-do/danh-sach?hopDongId=` | DS tien do theo hop dong  | `hopDongId` (query) | `List<TienDoDto>`   |
| GET         | `tien-do/chi-tiet/{id}`        | Chi tiet tien do          | -                   | `TienDoDto`         |
| DELETE      | `tien-do/xoa/{id}`             | Xoa tien do               | -                   | `ResultApi`         |

**Response DTO:**
```json
{
  "id": "Guid",
  "hopDongId": "Guid",
  "ten": "string",
  "phanTramKeHoach": 0,
  "ngayBatDauKeHoach": "DateOnly?",
  "ngayKetThucKeHoach": "DateOnly?",
  "moTa": "string?",
  "trangThaiId": 0,
  "tenTrangThai": "string?",
  "phanTramThucTe": 0,
  "ngayCapNhatGanNhat": "DateOnly?"
}
```

**Insert Model:**
```json
{
  "hopDongId": "Guid (required)",
  "ten": "string (required, max 500)",
  "phanTramKeHoach": 0,
  "ngayBatDauKeHoach": "DateOnly?",
  "ngayKetThucKeHoach": "DateOnly?",
  "moTa": "string? (max 2000)",
  "trangThaiId": 0
}
```

---

## BaoCaoTienDo (bao-cao-tien-do)

**Base Route:** `bao-cao-tien-do`
**Key Type:** `Guid`
**Type:** Full CRUD + Approval Workflow

| Phuong thuc | Duong dan                           | Mo ta                       | Request                    | Response               |
| ----------- | ----------------------------------- | --------------------------- | -------------------------- | ---------------------- |
| POST        | `bao-cao-tien-do/them-moi`          | Them moi bao cao            | `BaoCaoTienDoInsertModel`  | `BaoCaoTienDoDto`      |
| PUT         | `bao-cao-tien-do/cap-nhat/{id}`     | Cap nhat bao cao            | `BaoCaoTienDoUpdateModel`  | `BaoCaoTienDoDto`      |
| GET         | `bao-cao-tien-do/danh-sach?tienDoId=` | DS bao cao theo tien do   | `tienDoId` (query)         | `List<BaoCaoTienDoDto>`|
| GET         | `bao-cao-tien-do/chi-tiet/{id}`     | Chi tiet bao cao            | -                          | `BaoCaoTienDoDto`      |
| GET         | `bao-cao-tien-do/cho-duyet?nguoiDuyetId=` | DS cho duyet          | `nguoiDuyetId` (query)     | `List<BaoCaoTienDoDto>`|
| POST        | `bao-cao-tien-do/duyet/{id}`        | Duyet/tu choi bao cao       | `BaoCaoTienDoDuyetModel`   | `BaoCaoTienDoDto`      |
| DELETE      | `bao-cao-tien-do/xoa/{id}`          | Xoa bao cao                 | -                          | `ResultApi`            |

**Response DTO:**
```json
{
  "id": "Guid",
  "tienDoId": "Guid",
  "tenTienDo": "string?",
  "ngayBaoCao": "DateOnly",
  "nguoiBaoCaoId": 0,
  "tenNguoiBaoCao": "string",
  "phanTramThucTe": 0,
  "noiDungDaLam": "string? (max 4000)",
  "keHoachTiepTheo": "string? (max 4000)",
  "ghiChu": "string? (max 2000)",
  "canDuyet": false,
  "daDuyet": false,
  "nguoiDuyetId": "long?",
  "tenNguoiDuyet": "string?",
  "ngayDuyet": "DateOnly?",
  "trangThaiDuyet": "string"
}
```

**Insert Model:**
```json
{
  "tienDoId": "Guid (required)",
  "ngayBaoCao": "DateOnly (required)",
  "nguoiBaoCaoId": 0,
  "tenNguoiBaoCao": "string? (max 200)",
  "phanTramThucTe": 0,
  "noiDungDaLam": "string? (max 4000)",
  "keHoachTiepTheo": "string? (max 4000)",
  "ghiChu": "string? (max 2000)",
  "canDuyet": false,
  "nguoiDuyetId": "long? (required if canDuyet=true)",
  "tenNguoiDuyet": "string? (required if canDuyet=true)"
}
```

**Duyet Model:**
```json
{
  "nguoiDuyetId": 0,
  "tenNguoiDuyet": "string",
  "duyet": true
}
```

---

## KhoKhanVuongMac (kho-khan-vuong-mac)

**Base Route:** `kho-khan-vuong-mac`
**Key Type:** `Guid`
**Type:** Full CRUD (filter by HopDong)

| Phuong thuc | Duong dan                               | Mo ta                      | Request                   | Response                 |
| ----------- | --------------------------------------- | -------------------------- | ------------------------- | ------------------------ |
| POST        | `kho-khan-vuong-mac/them-moi`           | Them moi kho khan          | `KhoKhanVuongMacInsertModel` | `KhoKhanVuongMacDto` |
| PUT         | `kho-khan-vuong-mac/cap-nhat/{id}`      | Cap nhat kho khan          | `KhoKhanVuongMacUpdateModel` | `KhoKhanVuongMacDto` |
| GET         | `kho-khan-vuong-mac/danh-sach?hopDongId=` | DS kho khan theo hop dong | `hopDongId` (query)       | `List<KhoKhanVuongMacDto>` |
| GET         | `kho-khan-vuong-mac/chi-tiet/{id}`      | Chi tiet kho khan          | -                         | `KhoKhanVuongMacDto`     |
| DELETE      | `kho-khan-vuong-mac/xoa/{id}`           | Xoa kho khan               | -                         | `ResultApi`              |

**Response DTO:**
```json
{
  "id": "Guid",
  "hopDongId": "Guid",
  "tienDoId": "Guid?",
  "tenTienDo": "string?",
  "noiDung": "string (max 2000)",
  "mucDo": "string? (max 50)",
  "ngayPhatHien": "DateOnly",
  "ngayGiaiQuyet": "DateOnly?",
  "bienPhapKhacPhuc": "string? (max 2000)",
  "trangThaiId": 0,
  "tenTrangThai": "string?"
}
```

**Insert Model:**
```json
{
  "hopDongId": "Guid (required)",
  "tienDoId": "Guid?",
  "noiDung": "string (required, max 2000)",
  "mucDo": "string? (max 50)",
  "ngayPhatHien": "DateOnly (required)",
  "ngayGiaiQuyet": "DateOnly?",
  "bienPhapKhacPhuc": "string? (max 2000)",
  "trangThaiId": 0
}
```

---

# Part C: Legacy/Reference

> Xem chi tiet tai `api-mapping-controllers_v0_0_2.md`

---

**Last Updated:** 2026-03-27
**Version:** v0.0.4