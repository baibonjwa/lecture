using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Entities;

namespace lecture.Model.Abstract
{
    public interface IItemTypeRepository
    {
        Boolean AddItemType(ItemTypeInfo lr);

        Boolean RemoveItemType(int id);

        Boolean UpdateItemType(ItemTypeInfo lr);

        ItemTypeInfo GetItemTypeByID(int Id);

        List<ItemTypeInfo> GetAllItemType();

        ItemTypeInfo GetItemTypeByTypeAndName(String type, String name);
    }
}