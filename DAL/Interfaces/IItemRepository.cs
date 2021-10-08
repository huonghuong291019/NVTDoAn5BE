using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace DAL
{
    public partial interface IItemRepository
    {
        List<ItemModel> GetDataAll();
        List<ItemModel> GetDataBuy();
        ItemModel GetDatabyIDSwish(string id);
        List<ItemModel> GetDataSwish();
        List<ItemModel> GetDataGetSwish();
        bool Create(ItemModel model);
        ItemModel GetDatabyID(string id);
        bool Update(ItemModel model);
        bool Delete(string id);
        List<ItemModel> GetDataSameItem(string maloai);
        List<ItemModel> SearchNameHome(int pageIndex, int pageSize, out long total, string tencaycanh);
        List<ItemModel> Search(int pageIndex, int pageSize, out long total, string maloai);
        List<ItemModel> SearchItemName(int pageIndex, int pageSize, out long total, string tencaycanh);

    }
}
