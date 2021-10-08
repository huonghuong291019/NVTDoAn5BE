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

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemBusiness _itemBusiness;
        public ItemController(IItemBusiness itemBusiness, IConfiguration configuration)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ItemModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }
        [Route("get-buy")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDatabBuy()
        {
            return _itemBusiness.GetDataBuy();
        }
        [Route("get-by-id-swish/{id}")]
        [HttpGet]
        public ItemModel GetDatabyIDSwish(string id)
        {
            return _itemBusiness.GetDatabyIDSwish(id);
        }
        [Route("get-swish")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDatabSwish()
        {
            return _itemBusiness.GetDataSwish();
        }
        [Route("get-data-swish")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDatabGetSwish()
        {
            return _itemBusiness.GetDataGetSwish();
        }
        [Route("get-same-item/{maloai}")]
        [HttpGet]
        public IEnumerable<ItemModel> GetDataSameItem(string maloai)
        {
            return _itemBusiness.GetDataSameItem(maloai);
        }
        [Route("searchnamehome")]
        [HttpPost]
        public ResponseModel SearchNameHome([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tencaycanh = "";
                if (formData.Keys.Contains("tencaycanh") && !string.IsNullOrEmpty(Convert.ToString(formData["tencaycanh"]))) { tencaycanh = Convert.ToString(formData["tencaycanh"]); }
                long total = 0;
                var data = _itemBusiness.SearchNameHome(page, pageSize, out total, tencaycanh);
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
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string maloai = "";
                if (formData.Keys.Contains("maloai") && !string.IsNullOrEmpty(Convert.ToString(formData["maloai"]))) { maloai = Convert.ToString(formData["maloai"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, maloai);
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
