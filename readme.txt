1. Copy dlls (Website, BusinessManager, Utilities)
2. Copy web.config keys and change as neceesary
3. Install System.Web.Optimization (Install-Package Microsoft.AspNet.Web.Optimization)
4. Add UI Files (Content, Scripts, Files, Views)
5. Add Route Config
routes.MapRoute(
               name: "Administration",
               url: "admin/{controller}/{action}/{id}",
               defaults: new { controller = "ManageMenu", action = "Index", id = UrlParameter.Optional }
           );  
6. Add HomeController
7. Add BusinessManager
   Add Business, Data, Models folders
   Install MySql.Data
8. Add Reference to System.Configuration
9. Add Reference to BusinessManager_Core
10. Add Reference to BusinessManager from WebSite

11. Add to HomeController
public ActionResult ForeignKeyDisplay(string fieldName, int? fieldValue, string primaryTable, bool readOnly)
        {
            //Search in Core, then in Local
            Type t = Type.GetType("BusinessManager.Business." + primaryTable + "BO, BusinessManager_Core");
            if (t == null)
            {
                t = Type.GetType("BusinessManager.Business." + primaryTable + "BO, BusinessManager");
            }

            List<BaseUIModel> list = null;

            if (t != null)
            {
                object instance = t.GetMethod("GetInstance").Invoke(null, null);
                object[] parametersArray = new object[] { 0 };
                var collection = (IEnumerable)t.GetMethod("GetAll").Invoke(instance, parametersArray);

                list = new List<BaseUIModel>();


                foreach (var item in collection)
                {
                    list.Add(new BaseUIModel()
                    {
                        ID = Convert.ToInt32(item.GetType().GetProperty("ID").GetValue(item, null)),
                        Name = Convert.ToString(item.GetType().GetProperty("Name").GetValue(item, null))
                    });
                }
            }

            ForeignKeyUIModel model = new ForeignKeyUIModel();
            model.Value = fieldValue;
            model.Collection = list;
            model.Name = fieldName;
            model.ReadOnly = readOnly;

            return View(model);
        }


12. Replace "ForeignKeyDisplay", "Admin" to "ForeignKeyDisplay", "Home"
13. Move ForeignKeyDisplay.cshtml to Shared
14. Adicionar System.Web to BusinessManager
15. Adicionar filters.Add(new CheckAuthentication()); to FilterConfig en Website
