using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IItemBusiness
    {
        List<ItemModel> GetDataAll();
        List<ItemModel> GetDataBuy();
        ItemModel GetDatabyIDSwish(string id);
        List<ItemModel> GetDataSwish();
        List<ItemModel> GetDataGetSwish();
        bool Create(ItemModel model);
        bool Update(ItemModel model);
        bool Delete(string id);
        ItemModel GetDatabyID(string id);
        List<ItemModel> GetDataSameItem(string maloai);
        List<ItemModel> SearchNameHome(int pageIndex, int pageSize, out long total, string tencaycanh);
        List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
        List<ItemModel> SearchItemName(int pageIndex, int pageSize, out long total, string tencaycanh);

    }
}
