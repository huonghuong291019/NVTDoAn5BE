using DAL;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ItemBusiness : IItemBusiness
    {
        private IItemRepository _res;
        private string Secret;
        public List<ItemModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ItemModel> GetDataBuy()
        {
            return _res.GetDataBuy();
        }
        public ItemModel GetDatabyIDSwish(string id)
        {
            return _res.GetDatabyIDSwish(id);
        }
        public List<ItemModel> GetDataSwish()
        {
            return _res.GetDataSwish();
        }
        public List<ItemModel> GetDataGetSwish()
        {
            return _res.GetDataGetSwish();
        }
        public List<ItemModel> GetDataSameItem(string maloai)
        {
            return _res.GetDataSameItem(maloai);
        }
        public List<ItemModel> SearchNameHome(int pageIndex, int pageSize, out long total, string tencaycanh)
        {
            return _res.SearchNameHome(pageIndex, pageSize, out total, tencaycanh);
        }
        public ItemBusiness(IItemRepository ItemGroupRes, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = ItemGroupRes;
        }
        public bool Create(ItemModel model)
        {
            return _res.Create(model);
        }
        public ItemModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ItemModel model)
        {
            return _res.Update(model);
        }
       
        public List<ItemModel> Search(int pageIndex, int pageSize, out long total, string maloai)
        {
            return _res.Search(pageIndex, pageSize, out total, maloai);
        }
        public List<ItemModel> SearchItemName(int pageIndex, int pageSize, out long total, string tencaycanh)
        {
            return _res.SearchItemName(pageIndex, pageSize, out total, tencaycanh);
        }
    }

}
