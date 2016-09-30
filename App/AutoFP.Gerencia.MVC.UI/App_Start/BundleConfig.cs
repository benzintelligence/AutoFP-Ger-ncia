using System.Web.Optimization;

namespace AutoFP.Gerencia.MVC.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/modalRemover").Include(
                      "~/Scripts/_custom/modalRemover.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/notification").Include(
                      "~/Scripts/_custom/notificacao.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/fornecedor").Include(
                      "~/Scripts/_custom/PessoaJuridica/pessoaJuridica.js",
                      "~/Scripts/_custom/Telefone/telefone.js",
                      "~/Scripts/_custom/Endereco/endereco.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/peca").Include(
                      "~/Scripts/_custom/Peca/peca.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/cliente").Include(
                      "~/Scripts/_custom/Cliente/cliente.js",
                      "~/Scripts/_custom/fullClickablePanelHeading.js",
                      "~/Scripts/_custom/PessoaJuridica/pessoaJuridica.js",
                      "~/Scripts/_custom/Endereco/endereco.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/pedido").Include(
                      "~/Scripts/_custom/Cliente/cliente.js"
                ));
            #endregion

            #region Styles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                          "~/Content/bootstrap.css",
                          "~/Content/site.css",
                          "~/Content/fullClickablePanelHeading.css"));
            #endregion
        }
    }
}