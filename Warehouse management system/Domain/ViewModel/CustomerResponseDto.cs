﻿using Warehouse_management_system.Models;

namespace Warehouse_management_system.Domain.ViewModel
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public List<PackageResponseDto> Packages { get; set; } = new();
    }
}