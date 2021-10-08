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
    public class ItemAdminController : ControllerBase
    {
        private IItemBusiness _itemBusiness;

        private string _path;
        public ItemAdminController(IItemBusiness itemBusiness, IConfiguration configuration)
        {
            _itemBusiness = itemBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ItemModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("create-item")]
        [HttpPost]
        public ItemModel Create([FromBody] ItemModel model)
        {
            model.macaycanh = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }
        [Route("delete-item")]
        [HttpPost]
        public IActionResult DeleteItem([FromBody] Dictionary<string, object> formData)
        {
            string macaycanh = "";
            if (formData.Keys.Contains("macaycanh") && !string.IsNullOrEmpty(Convert.ToString(formData["macaycanh"]))) { macaycanh = Convert.ToString(formData["macaycanh"]); }
            _itemBusiness.Delete(macaycanh);
            return Ok();
        }
        [Route("update-item")]
        [HttpPost]
        public ItemModel UpdateItem([FromBody] ItemModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public ResponseModel SearchItemName([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tencaycanh = "";
                if (formData.Keys.Contains("tencaycanh") && !string.IsNullOrEmpty(Convert.ToString(formData["tencaycanh"])))
                {
                    tencaycanh = Convert.ToString(formData["tencaycanh"]);
                }
                long total = 0;
                var data = _itemBusiness.SearchItemName(page, pageSize, out total, tencaycanh);
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
