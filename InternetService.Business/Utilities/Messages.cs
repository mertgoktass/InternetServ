using DynobilV3.Entities.Concrete;
using DynobilV3.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynobilV3.Business.Utilities
{
    public static class Messages
    {
        public static string AddingCompleted = "Ekleme Başarılı";
        public static string UpdatingCompleted = "Güncelleme Başarılı";
        public static string DeletingCompleted = "Silme Başarılı";
        public static string ListingCompleted = "Listeleme Başarılı";
        public static string GettingCompleted = "Görüntüleme Başarılı";

        public static string ThereIsNoDataInTable = "Tabloda Hiç Veri Yok!";

        public static string AddingNotCompleted = "Ekleme Başarısız!";
        public static string UpdatingNotCompleted = "Güncelleme Başarısız!";
        public static string DeletingNotCompleted = "Silme Başarısız!";
        public static string ListingNotCompleted = "Listeleme Başarısız!";
        public static string GettingNotCompleted = "Görüntüleme Başarısız!";
    }
}
