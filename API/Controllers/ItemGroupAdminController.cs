using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemGroupAdminController : ControllerBase
    {
        private string _path;
        private IItemGroupBusiness _itemGroupBusiness;
        public ItemGroupAdminController(IItemGroupBusiness itemGroupBusiness, IConfiguration configuration)
        {
            _itemGroupBusiness = itemGroupBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        [AllowAnonymous]
        [Route("delete-itemgroup")]
        [HttpPost]
        public IActionResult DeleteItemGroup([FromBody] Dictionary<string, object> formData)
        {
            string maloai = "";
            if (formData.Keys.Contains("maloai") && !string.IsNullOrEmpty(Convert.ToString(formData["maloai"]))) { maloai = Convert.ToString(formData["maloai"]); }
            _itemGroupBusiness.Delete(maloai);
            return Ok();
        }

        [Route("create-itemgroup")]
        [HttpPost]
        public ItemGroupModel CreateItemGroup([FromBody] ItemGroupModel model)
        {
            model.maloai = Guid.NewGuid().ToString();
            _itemGroupBusiness.Create(model);
            return model;
        }

        [Route("update-itemgroup")]
        [HttpPost]
        public ItemGroupModel UpdateItemGroup([FromBody] ItemGroupModel model)
        {
            _itemGroupBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ItemGroupModel GetDatabyID(string id)
        {
            return _itemGroupBusiness.GetDatabyID(id);
        }
        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<ItemGroupModel> GetAllMenu()
        {
            return _itemGroupBusiness.GetData();
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenloai = "";
                if (formData.Keys.Contains("tenloai") && !string.IsNullOrEmpty(Convert.ToString(formData["tenloai"]))) { tenloai = Convert.ToString(formData["tenloai"]); }
                long total = 0;
                var data = _itemGroupBusiness.Search(page, pageSize, out total, tenloai);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

    }
}
