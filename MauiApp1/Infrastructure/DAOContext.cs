using MauiApp1.Domaine;
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
            return null;//new SQLiteAsyncConnection(GlobalSetting.DatabasePath, GlobalSetting.Flags);
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
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Vache).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Vache)).ConfigureAwait(false);
                    await Database.InsertAllAsync(new List<Vache> {
                            new Vache{ Name = "Cow 1" } ,
                            new Vache{ Name = "Cow 2" } ,
                            new Vache{ Name = "Cow 3" } ,
                                                        });
                }
                
                initialized = true;
            }
        }
    }
}

