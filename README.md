# T4 WebForms Injection

T4 WebForms Injection is a T4 template for ASP.NET WebForms that creates parameterless constructors for classes that have a dependency injectable constructor, but are created via a sealed factory.

### Targets subclasses of
* System.Web.UI.MasterPage
* System.Web.UI.Page
* System.Web.UI.UserControl
* System.Web.IHttpHandler
* System.Web.IHttpModule
* Additional base classes can be added/removed via *T4WebFormsInjection.tt.settings.xml*

### Requirements
* The target class must be partial
* No parameterless constructor can already exist (a compiler error will be thrown if one already exist)
* Every parameter in the constructor will be injected

### Steps to install/configure
* **Install** T4WebFormsInjection in your app using [NuGet](https://www.nuget.org/packages/T4WebFormsInjection/)
* **Edit** the [configuration file](https://github.com/EtherZa/T4WebFormsInjection/wiki/Configuration)
* **Run custom tool** to generate the template

### Credits
* Settings code harvested from [T4MVC](https://github.com/T4MVC/T4MVC)
* Manager.tt from [Damien Guard](http://damieng.com/blog/2009/11/06/multiple-outputs-from-t4-made-easy-revisited)
