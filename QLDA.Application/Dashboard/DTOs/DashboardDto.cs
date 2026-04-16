// Re-export DTOs from Domain layer for Application layer use
// This maintains backward compatibility and follows Clean Architecture
global using QLDA.Domain.DTOs;

namespace QLDA.Application.Dashboard.DTOs;

// Empty namespace - all DTOs are defined in QLDA.Domain.DTOs