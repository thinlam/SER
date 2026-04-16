# Project Overview and Product Development Requirements (PDR) - QLDA

This document outlines the purpose, scope, target users, core functional and non-functional requirements, technical constraints, and integration points for the QLDA (Quản Lý Dự Án - Project Management System) application.

## 1. Project Purpose and Scope

QLDA is a comprehensive .NET 8.0 Clean Architecture Web API designed to manage government IT projects for Ho Chi Minh City, Vietnam. Its primary purpose is to streamline the lifecycle of IT projects, from planning and bidding to execution, financial management, and reporting, ensuring transparency and efficiency in government operations.

The scope of this project covers the backend API development, providing robust services for data management, business logic execution, and integration with various government systems. Frontend development is out of scope for this document but relies on this API.

## 2. Target Users

The primary target users for the QLDA system are government officials and administrators within Ho Chi Minh City involved in the management, oversight, and execution of IT projects. This includes:

-   **Project Managers:** For planning, tracking, and reporting on project progress.
-   **Financial Officers:** For managing budgets, payments, and financial approvals.
-   **Procurement Specialists:** For managing bid packages and contracts.
-   **Department Heads/Decision Makers:** For reviewing reports and making strategic decisions.
-   **Auditors:** For verifying compliance and project records.

## 3. Core Functional Requirements

The QLDA system is structured around six main modules, reflecting key aspects of project management:

### 3.1. Project Management (DuAn)
-   Create, read, update, and delete (CRUD) projects with hierarchical structures (ParentId).
-   Track project phases and milestones.
-   Assign and manage project teams and stakeholders.

### 3.2. Project Steps Tracking (DuAnBuoc)
-   Define and manage individual steps or tasks within a project.
-   Track progress and status of each step.
-   Associate documents and responsibilities with steps.

### 3.3. Bid Package Management (GoiThau)
-   Manage the lifecycle of bid packages, from creation to award.
-   Store bid documents, criteria, and evaluation results.
-   Track tender statuses and timelines.

### 3.4. Contract Management (HopDong)
-   CRUD contracts and associated legal documents.
-   Manage contract amendments and annexes (PhuLucHopDong).
-   Track contract values, terms, and compliance.

### 3.5. Financial Management (ThanhToan/TamUng)
-   Process and track project payments and advances.
-   Manage budget allocations and expenditures.
-   Generate financial reports.

### 3.6. Reporting and Decision Support (BaoCao & VanBanQuyetDinh)
-   Generate various progress reports (BaoCao).
-   Manage official decision documents and legal frameworks (VanBanQuyetDinh).
-   Provide audit trails for project activities.

### 3.7. Master Data Management (DanhMuc*)
-   Centralized management of various category/master data tables (e.g., DanhMucLoaiDuAn, DanhMucTrangThaiDuAn) to ensure data consistency and integrity across the system.

## 4. Non-Functional Requirements (NFRs)

### 4.1. Performance
-   **Response Time:** API responses for typical queries (e.g., list projects, get project details) should be within 500ms under normal load. Complex reports might take longer but should not exceed 5 seconds.
-   **Scalability:** The system should be able to handle up to 1,000 concurrent users without significant performance degradation. The architecture should support horizontal scaling for future growth.
-   **Throughput:** Support at least 100 transactions per second for common operations.

### 4.2. Security
-   **Authentication:** Implement JWT Bearer authentication for all API endpoints.
-   **Authorization:** Role-based access control (RBAC) to ensure users can only access resources and perform actions relevant to their assigned roles.
-   **Data Protection:** All sensitive data must be encrypted at rest and in transit.
-   **Vulnerability Management:** Regular security audits and penetration testing to identify and mitigate vulnerabilities (e.g., OWASP Top 10).
-   **Audit Trails:** Comprehensive logging of all critical system activities and data modifications.

### 4.3. Reliability & Availability
-   **Uptime:** The API should maintain an uptime of 99.9% (excluding scheduled maintenance).
-   **Error Handling:** Robust error handling and logging mechanisms with informative error messages without exposing sensitive internal details.
-   **Data Backup & Recovery:** Regular automated database backups with a defined recovery point objective (RPO) and recovery time objective (RTO).

### 4.4. Maintainability & Extensibility
-   **Code Quality:** Adherence to Clean Architecture principles, coding standards, and best practices.
-   **Modularity:** Loosely coupled components to facilitate independent development and deployment.
-   **Documentation:** Comprehensive and up-to-date documentation for code, architecture, and APIs.
-   **Testability:** High test coverage for business logic and critical components.

## 5. Technical Constraints

-   **.NET 8.0:** The application must be developed using .NET 8.0 framework.
-   **ASP.NET Core Web API:** The backend must be an ASP.NET Core Web API.
-   **SQL Server:** The primary database must be SQL Server.
-   **Aspose:** Use Aspose for Office document generation and processing.
-   **Clean Architecture:** Strict adherence to the Clean Architecture principles.

## 6. Integration Points

The QLDA system is designed to integrate with other government systems and services:

-   **Authentication System:** Integration with an existing identity provider for user authentication and management.
-   **Document Management System:** Potential integration for storing and retrieving official documents.
-   **Reporting Dashboards:** APIs will provide data feeds for external reporting and analytics dashboards.
-   **Email/Notification Services:** For sending automated notifications related to project milestones, deadlines, or approvals.
-   **Geographic Information Systems (GIS):** Potentially for mapping project locations (future consideration).

---
*This document will be updated as the project evolves.*
