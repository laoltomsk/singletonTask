using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class GodSingleton
    {

        /*
         * Приватный конструктор делает невозможным создание объекта через new,
         * и единственным [известным мне] способом остаётся использование getInstance.
         * Этот метод должен быть статическим (иначе к нему будет невозможно обратиться),
         * соответственно, приватное поле с инстансом тоже статический.
         * 
         * В то же время, поля для данных (тут для примера создан name) нестатические,
         * чтобы при сохранении .getInstance() в переменную с ними было удобно взаимодействовать.
         * 
         * Во избежание одновременного создания _instance в двух потоках используется lock.
         */
        
        private static GodSingleton _instance;

        private GodSingleton() { }

        private static Object _locker = new Object();

        public static GodSingleton getInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    _instance = new GodSingleton();
                }
            }

            return _instance;
        }

        public String name;
    }
}
