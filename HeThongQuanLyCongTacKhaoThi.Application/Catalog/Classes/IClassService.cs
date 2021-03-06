﻿using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Classes;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Classes
{
    public interface IClassService
    {
        Task<string> Create(ClassCreateRequest request);

        Task<int> Delete(string ClassID);

        Task<bool> UpdateName(string classID, string name);

        Task<bool> IncreaseStudentCount(string classID, int count);

        Task<bool> DecreaseStudentCount(string classID, int count);

        Task<PagedResult<ClassViewModel>> GetAllPaging(ClassPagingRequest request);

        Task<ClassViewModel> GetByID(string classID);
    }
}