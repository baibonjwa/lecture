using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using lecture.Model.Abstract;
using lecture.Model.Entities;
using System.Data.SqlClient;
using System.Data;

namespace lecture.Model.Concrete
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        private List<ItemTypeInfo> list;
        public Boolean AddItemType(ItemTypeInfo lr)
        {
            string sql = "insert into tb_itemType values(@itemType,@itemName,@itemDescription)";
            SqlParameter itemType = new SqlParameter("@itemType", lr.ItemType);
            SqlParameter itemName = new SqlParameter("@itemName", lr.ItemName);
            SqlParameter itemDescription = new SqlParameter("@itemDescription", lr.ItemDescription);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, itemType, itemName, itemDescription);
            return true;
        }

        public Boolean RemoveItemType(int id)
        {
            string sql = "delete from tb_itemType where itemtypeid=@itemTypeid";
            SqlParameter itemTypeid = new SqlParameter("@itemTypeid",id);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, itemTypeid);
            return true;
        }

        public Boolean UpdateItemType(ItemTypeInfo lr)
        {
            string sql = "update tb_itemType set itemType=@itemType,itemName=@itemName,itemDescription=@itemDescription where itemtypeid=@itemtypeid";
            SqlParameter itemtypeid = new SqlParameter("@itemtypeid", lr.ItemTypeID);
            SqlParameter itemType = new SqlParameter("@itemType", lr.ItemType);
            SqlParameter itemName = new SqlParameter("@itemName", lr.ItemName);
            SqlParameter itemDescription = new SqlParameter("@itemDescription", lr.ItemDescription);
            SqlHelper.ExecuteNonQuery(SqlHelper.GetConnection(), CommandType.Text, sql, itemtypeid, itemType, itemName, itemDescription);
            return true;
        }

        public ItemTypeInfo GetItemTypeByID(int Id)
        {
            list = new List<ItemTypeInfo>();
            ItemTypeInfo data = null;
            string sql = "select * from tb_itemType where itemTypeID=@id";
            SqlParameter paramID = new SqlParameter("@id", Id);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, paramID))
            {
                while (dr.Read())
                {
                    data = new ItemTypeInfo();
                    data.ItemTypeID = Convert.ToInt32(dr["itemTypeID"]);
                    data.ItemType = dr["itemType"].ToString();
                    data.ItemName = dr["itemName"].ToString();
                    data.ItemDescription = dr["itemDescription"].ToString();
                }
            }
            return data;
        }
        public ItemTypeInfo GetItemTypeByTypeAndName(String type, String name)
        {
            list = new List<ItemTypeInfo>();
            ItemTypeInfo data = null;
            string sql = "select * from tb_itemType where itemType=@type and itemName=@name";
            SqlParameter ptype = new SqlParameter("@type", type);
            SqlParameter pname = new SqlParameter("@name", name);
            using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.GetConnection(), CommandType.Text, sql, ptype, pname))
            {
                while (dr.Read())
                {
                    data = new ItemTypeInfo();
                    data.ItemTypeID = Convert.ToInt32(dr["itemTypeID"]);
                    data.ItemType = dr["itemType"].ToString();
                    data.ItemName = dr["itemName"].ToString();
                    data.ItemDescription = dr["itemDescription"].ToString();
                }
            }
            return data;
        }

        public List<ItemTypeInfo> GetAllItemType()
        {
            return null;
        }
    }
}