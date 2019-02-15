using System;
using InduccionMVVM.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace InduccionMVVM.Services
{


    public interface iApiService
    {
        Task<List<Products>> GetProducts(string filter = null);
    }
}
