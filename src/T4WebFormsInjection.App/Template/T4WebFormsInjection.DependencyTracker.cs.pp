namespace $rootnamespace$
{
    using System.Collections.Generic;

    /// <summary>
    /// Sample container implementation for T4WebformsInjection for IOC framework that does not make use of scoped lifetimes.
    /// </summary>
    /// <remarks>
    /// This sample needs to be customized to make use of your IOC implementation.
    /// </remarks>
    internal class T4WebFormsInjectionScopedContainer : $rootnamespace$.T4WebFormsInjection.IScopedContainer
    {
        private readonly List<object> trackedObjects;

        /// <summary>
        /// Constructs a new instance of the <see cref="T4WebFormsInjectionScopedContainer"/> class.
        /// </summary>
	    public T4WebFormsInjectionScopedContainer()
	    {
	        this.trackedObjects = new List<object>();
	    }

		/// <summary>
		/// Resolve instance of <see cref="T"/>.
		/// </summary>
		/// <typeparam name="T">Type to be resolved.</typeparam>
		/// <returns>Instance of <see cref="T"/></returns>
		public T Resolve<T>()
			where T: class
		{
			// TODO: Resolve instance here
			this.trackedObjects.Add(o);
			return o;
		}

		/// <summary>
		/// Release all instances created by this scoped container.
		/// </summary>
	    public void ReleaseAll()
	    {
	        foreach (var trackedObject in this.trackedObjects)
	        {
				// TODO: release instance
	        }

			this.trackedObjects.Clear();
	    }
    }
}