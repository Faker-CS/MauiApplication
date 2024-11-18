using MauiApp1.Helper;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Infrastructure
{
    public class DAOContext
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(GlobalSetting.DatabasePath, GlobalSetting.Flags);
        });

        public static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        readonly Action<Exception> OnError;
        public DAOContext()
        {
            OnError = new Action<Exception>((x) => {
                Console.WriteLine("erreur DaoContext : " + x.Message);
                //throw x; 
            });
            InitializeAsync().SafeFireAndForget(false, OnError);
        }
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Rayon).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Rayon)).ConfigureAwait(false);
                    await Database.InsertAllAsync(new List<Rayon> {
                            new Rayon{ Libelle = "Rayon 1" } ,
                            new Rayon{ Libelle = "Rayon 2" } ,
                            new Rayon{ Libelle = "Rayon 3" } ,
                                                        });
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Fournisseur).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Fournisseur)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Produit).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Produit)).ConfigureAwait(false);
                }
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Mouvement).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Mouvement)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
    }
}
}
