# So Sánh Kiến Trúc: Monolith Coupled vs Modular Backend

## 1. Tổng Quan

### 1.1 Kiến Trúc Hiện Tại (DichVuDungChung)

**Tên kiến trúc:** Two-Tier Monolith / Frontend-Backend Coupled Architecture

```
DichVuDungChung/
├── GUI/                          # Frontend Layer
│   ├── Controllers/              # MVC Controllers
│   ├── Views/                    # Razor Views
│   ├── Scripts/                  # JavaScript/CSS
│   └── Models/                   # View Models
├── SER/                          # Backend Layer (DDD)
│   ├── DVDC.Domain/
│   ├── DVDC.Application/
│   ├── DVDC.Persistence/
│   ├── DVDC.Infrastructure/
│   └── DVDC.WebApi/
└── HelperCommon/                 # Shared Utilities
```

**Đặc điểm:**
- FE và BE nằm cùng 1 repository
- GUI là MVC project (DNN DesktopModule)
- SER là Backend theo DDD
- Tightly coupled giữa FE và BE

---

### 1.2 Kiến Trúc Mới (BuildingBlocks/modules)

**Tên kiến trúc:** Modular Monolithic Backend / Shared Kernel Architecture

```
BuildingBlocks/
├── src/                          # Shared Kernel
│   ├── BuildingBlocks.Domain/
│   ├── BuildingBlocks.Application/
│   ├── BuildingBlocks.Persistence/
│   ├── BuildingBlocks.Infrastructure/
│   └── BuildingBlocks.CrossCutting/
├── modules/                      # Backend Modules Only
│   └── QLHD/
│       ├── QLHD.Domain/
│       ├── QLHD.Application/
│       ├── QLHD.Persistence/
│       ├── QLHD.Infrastructure/
│       └── QLHD.WebApi/
└── tests/
```

**Đặc điểm:**
- Chỉ chứa Backend code
- Shared Kernel tái sử dụng giữa các module
- Frontend tách biệt (repository khác hoặc project khác)
- Loose coupling, high cohesion

---

## 2. Nỗi Đau Hiện Tại (Pain Points)

### 2.1 Bối Cảnh Thực Tế

- **Solo Developer BE:** Chỉ có 1 người code Backend, không làm Frontend
- **Multiple VSCode Windows:** Mỗi module mở 1 cửa sổ VSCode riêng → switching liên tục, mất focus
- **Fragmented Codebase:** Code phân tán ở nhiều nơi, khó maintain

### 2.2 Vấn Đề Cụ Thể

| # | Pain Point | Mô Tả | Impact |
|---|------------|-------|--------|
| 1 | **Nhiều cửa sổ VSCode** | DVDC, QLHD, QLDA, NVTT mỗi cái 1 window | Mất 5-10s mỗi lần switch, dễ nhầm lẫn |
| 2 | **Duplicate Code** | Cùng 1 class/entity tồn tại ở nhiều module | Sửa 1 chỗ, quên chỗ khác → bug |
| 3 | **BuildingBlocks không sync** | Sửa BuildingBlocks ở 1 module, module khác không được cập nhật | Inconsistency, duplicate effort |
| 4 | **Không có single source of truth** | Mỗi module có version BuildingBlocks riêng | Version conflict, hard to track |
| 5 | **Refactoring nightmare** | Đổi tên 1 class phải sửa ở 4-5 nơi | Time-consuming, error-prone |

### 2.3 Mong Muốn Giải Quyết

```
🎯 Mục tiêu:
┌─────────────────────────────────────────────────────────────┐
│  1 CỬA SỔ VSCode                                           │
│  └── BuildingBlocks.sln                                     │
│       ├── src/           ← Sửa 1 lần, apply cho tất cả     │
│       └── modules/       ← Tất cả module ở 1 nơi           │
└─────────────────────────────────────────────────────────────┘
```

**Khi sửa BuildingBlocks:**
- ✅ Tự động propagate đến tất cả modules (ProjectReference)
- ✅ Build 1 lần, check toàn bộ
- ✅ Refactor 1 click, apply everywhere

---

## 3. So Sánh Chi Tiết

### 3.1 Bảng So Sánh

| Tiêu Chí | Kiến Trúc Cũ (Coupled) | Kiến Trúc Mới (Modular BE) |
|----------|------------------------|----------------------------|
| **FE/BE Separation** | ❌ Nằm chung repo | ✅ Tách biệt hoàn toàn |
| **Code Reuse** | ⚠️ Copy-paste giữa module | ✅ Shared Kernel central |
| **Deployment** | ❌ Deploy cùng lúc | ✅ Independent deployment |
| **Team Scaling** | ❌ Full-stack bắt buộc | ✅ FE/BE team riêng biệt |
| **Testing** | ⚠️ Khó test FE riêng | ✅ BE test isolation |
| **Technology Flexibility** | ❌ FE phụ thuộc DNN MVC | ✅ FE có thể là React/Vue/... |
| **Build Time** | ❌ Build cả FE + BE | ✅ Build riêng BE nhanh hơn |
| **Git Conflicts** | ⚠️ Nhiều conflict | ✅ Ít conflict hơn |
| **DNN Dependency** | ❌ Strong coupling | ⚠️ Chỉ WebApi phụ thuộc |
| **Migration Cost** | ✅ Không cần migrate | ❌ Cần refactor/migrate |

---

### 2.2 Ưu Điểm & Nhược Điểm

#### Kiến Trúc Cũ (Coupled)

**Ưu điểm:** 
- ✅ Debug FE/BE cùng lúc dễ dàng
- ✅ DNN integration tốt (built-in)

**Nhược điểm:**
- ❌ Code duplicate giữa các module
- ❌ Large scale switching giữa các module - khó bảo trì cùng lúc nhiều dự án
- ❌ Build/deploy lâu hơn

---

#### Kiến Trúc Mới (Modular Backend)

**Ưu điểm:**
- ✅ **Shared Kernel**: Tái sử dụng code giữa các module (Domain entities, DTOs, utilities)
- ✅ **Independent Deployment**: Deploy BE riêng, FE riêng
- ✅ **Technology Freedom**: FE có thể là React, Vue, Angular, hoặc giữ DNN MVC
- ✅ **Team Scaling**: FE team và BE team làm việc độc lập
- ✅ **Faster Build**: Build chỉ BE khi thay đổi BE
- ✅ **Better Testing**: Unit test BE không cần DNN context
- ✅ **Clean Architecture**: Domain layer không có dependency
- ✅ **API-First**: WebApi là entry point duy nhất

**Nhược điểm:**
- ❌ Cần setup CI/CD riêng cho BE
- ❌ Learning curve cho team chưa quen DDD

---

## 3. Tại Sao Nên Chuyển Đổi

### 3.1 Lý Do Kỹ Thuật

1. **Clean Architecture Compliance**
   - Domain layer không phụ thuộc infrastructure
   - Dependency rule: Domain ← Application ← Persistence/Infrastructure
   - Dễ thay đổi database, ORM, external services

2. **Shared Kernel Pattern**
   ```
   BuildingBlocks.Domain          # BaseEntity, interfaces
   BuildingBlocks.Application     # DTOs, behaviors, services
   BuildingBlocks.Persistence     # Generic repository, interceptors
   BuildingBlocks.Infrastructure  # DateTime, Excel, File helpers
   ```
   - Các module QLHD, QLDA, NVTT chỉ cần implement business logic riêng
   - Không duplicate code như hiện tại

3. **API-First Design**
   - WebApi là layer duy nhất expose endpoints
   - Dễ document (OpenAPI/Swagger)
   - Client-agnostic (web, mobile, third-party)

### 3.2 Lý Do Business

1. **Team Scaling**
   - BE team tập trung vào API
   - FE team có thể chọn technology stack phù hợp
   - Code review rõ ràng hơn

2. **Faster Time-to-Market**
   - Build riêng BE: 30s thay vì 2 phút
   - Deploy BE không ảnh hưởng FE
   - Hotfix nhanh hơn

3. **Future-Proof**
   - Dễ migrate sang microservices sau này
   - Dễ thay đổi FE technology
   - Mobile app có thể dùng API hiện tại

---
## 4. Kết Luận

**Nên chuyển đổi khi:**
- Cần scale development
- Cần hỗ trợ mobile app
- Cần thay đổi FE technology
- Cần deploy FE/BE riêng biệt
- Cần maintain trên nhiều dự án cùng lúc
---

## 5. Khuyến Nghị

**Khuyến nghị:** Chuyển đổi sang Modular Backend Architecture vì:

1. **Project đang tăng trưởng** → Cần architecture có thể scale
2. **Multiple modules** → Shared Kernel giảm duplicate code
3. **Future mobile support** → API-first design sẵn sàng
4. **Team expansion** → Clear separation cho collaboration

**Approach:** Incremental migration (từng module một) thay vì big-bang rewrite.

---

*Tài liệu này được tạo để hỗ trợ quyết định kiến trúc. Cần review với team trước khi implement.*