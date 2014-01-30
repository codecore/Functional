using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.IO;

using Functional;

namespace Functional.Implementation {
    public enum CompositionCode {
        Success,              // successfully resolved an export
        Unknown_Error,        // can not figure the error out
        No_Exports_Found,     // no exports were found
        Many_Exports_Found    // exports were found, but there was more than one, so they need to go in to a collection.
    };
    public interface IExtensibilityHost : IDisposable {
        CompositionCode SatisfyImports(object o);
    }
    public class ExtensibilityHost : IExtensibilityHost {

        private enum Sequence {
            Initial = 0,
            Compose = 1,
            SatisfyImports = 2
        }
        private Sequence sequence = Sequence.Initial;
        private CompositionContainer _container;
        private AssemblyCatalog assemblyCatalog;
        private DirectoryCatalog directoryCatalog;
        private void init() {
            
            var catalog = new AggregateCatalog();

            this.assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            catalog.Catalogs.Add(this.assemblyCatalog);

            this.directoryCatalog = new DirectoryCatalog((new FileInfo(Assembly.GetExecutingAssembly().Location)).DirectoryName);
            catalog.Catalogs.Add(this.directoryCatalog);

            this._container = new CompositionContainer(catalog);
            try {
                this._container.ComposeParts(this);
            } catch (CompositionException ex) {
                // TODO log this error
            }
            
        }
        public CompositionCode SatisfyImports(object o) {
            Validate.NonNullArgument(o, "object o");
            if (this.sequence != Sequence.Initial) throw new Exception("Composition sequence is incorrect");
            CompositionCode result = CompositionCode.Success;
            this.sequence = Sequence.Compose;
            this.init();
            try {
                this._container.SatisfyImportsOnce(o);

            } catch (CompositionException ex) {
                result = CompositionCode.Unknown_Error;
                // no way to determine actual error from the ex object.
                // possible errors are:
                //    More than one export was found that matches the constraint
                //    No exports were found that match the constraint
            }
            this.sequence = Sequence.SatisfyImports;
            return result;
        }
        virtual public string AssemblyInfo() {
            return Assembly.GetExecutingAssembly().ToString();
        }
        virtual public void Dispose() {
            if (null != this.assemblyCatalog) {
                this.assemblyCatalog.Dispose();
                this.assemblyCatalog = null;
            }
            if (null != this.directoryCatalog) {
                this.directoryCatalog.Dispose();
                this.directoryCatalog = null;
            }
            if (null != this._container) {
                this._container.Dispose();
                this._container = null;
            }
            this.sequence = Sequence.Initial;
        }
    }
}
