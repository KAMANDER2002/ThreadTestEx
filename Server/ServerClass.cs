using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestExecute1.Server
{
    public static class ServerClass
    {
        private static int count{ get; set; } //Переменная count данная по заданию
        private static ReaderWriterLock countLocker = new ReaderWriterLock(); //локер для чтения и записи переменной
        public static void AddToCount(int value)
        {
            countLocker.AcquireWriterLock(Timeout.InfiniteTimeSpan); //Блокируем чтение и запись от других пользователей
            count += value;
            countLocker.ReleaseWriterLock(); //разблокируем чтение и запись от других пользователей
        }

        public static int GetCount()
        {
            countLocker.AcquireReaderLock(Timeout.InfiniteTimeSpan);//если заблокировано то чтение не доступно
            try
            {
                return count; //Возврат если чтение доступно
            }
            finally
            {
                countLocker.ReleaseReaderLock();
            }
        }
    }
}
