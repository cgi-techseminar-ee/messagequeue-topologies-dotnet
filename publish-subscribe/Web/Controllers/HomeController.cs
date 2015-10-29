namespace Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Common;
    using Common.Messages;

    public class HomeController : Controller
    {
        private readonly MinistryDatabase db = new MinistryDatabase();

        public ActionResult Index()
        {
            return this.View(this.db.GetAll());
        }

        public async Task<ActionResult> Go(int id)
        {
            if (this.db.GetAll().All(a => a.Id != id))
            {
                return this.HttpNotFound();
            }

            var ministry = this.db.GetAll().First(a => a.Id == id);

            await MvcApplication.Publish(new DriveToOrder { Name = ministry.Name, Address = ministry.Address });

            return this.RedirectToAction("Index");
        }
    }
}