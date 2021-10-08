using DAL;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ItemGroupBusiness : IItemGroupBusiness
    {
        private IItemGroupRepository _res;
        public ItemGroupBusiness(IItemGroupRepository ItemGroupRes, IConfiguration configuration)
        {
            _res = ItemGroupRes;
        }

        public List<ItemGroupModel> GetData()
        {
            return _res.GetData();
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public ItemGroupModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public bool Create(ItemGroupModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ItemGroupModel model)
        {
            return _res.Update(model);
        }
        public List<ItemGroupModel> Search(int pageIndex, int pageSize, out long total, string item_group_name)
        {
            return _res.Search(pageIndex, pageSize, out total, item_group_name);
        }
    }

}
