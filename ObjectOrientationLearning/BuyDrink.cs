using System;
using System.Collections.Generic;

namespace ObjectOrientationLearning
{
    // <summary>
    // 自販機で飲み物を買う動作を行うプログラム
    // </summary>
    class BuyDrink
    {
        // 自販機の種類を宣言
        private static CocaCola cocaCola;
        private static Acure acure;
        private static Boss boss;

        // 所持金
        private static int money = 500;

        static void Main(string[] args)
        {
            // 【オブジェクト指向の基礎練習】
            // 自販機システム
            // システム要件：数台中身が別の商品を販売していること

            Console.WriteLine("自販機シミュレーション");
            Console.WriteLine("----------");
            Console.WriteLine("");

            cocaCola = new CocaCola();
            acure = new Acure();
            boss = new Boss();

            Console.WriteLine("現在の所持金は　" + money + "円で、");
            Console.WriteLine("");
            Console.WriteLine("とても喉が渇いて自販機に向かいました。");
            Console.WriteLine("");

            int vendingId = -1;
            while (vendingId == -1)
            {
                // 自販機を選ぶ
                vendingId = SelectVending();

                if(vendingId == 3)
                {
                    //　飲料状態を選択する
                    SelectStatus();
                }


                // 販売機の商品を見る
                ItemNames(vendingId);

                int button = -1;
                while (button == -1)
                {
                    // 商品を選ぶ
                    button = GetItem(vendingId);

                    // 自販機を変更する依頼がきてたら
                    if (button == -2)
                    {
                        button = -2;
                        vendingId = -1;
                    }
                }
                // 所持金からお金を販売機に入れて購入
                if (button >= 0)
                {
                    var item = Pyment(vendingId, button);
                }
            }
        }

        /// <summary>
        /// 自販機を選ぶ
        /// </summary>
        /// <returns>自販機選択値</returns>
        private static int SelectVending()
        {
            Console.WriteLine("++++++++++");
            Console.WriteLine("自販機を選択する");
            Console.WriteLine("「CocaCola」は1");
            Console.WriteLine("「Acure」は2");
            Console.WriteLine("「Boss」は3");
            Console.WriteLine("");

            // 自販機の選択値を取得する
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// 購入する商品を選択する
        /// </summary>
        /// <param name="selectVending">選択した自販機</param>
        /// <returns></returns>
        private static int GetItem(int selectVending)
        {
            // 商品を選ぶ
            var button = -1;
            var itemName = Console.ReadLine();
            // 商品名以外の情報が入っていたら
            if (itemName == "戻る")
            {
                // 自販機を選び直す
                return -2;
            }

            // 選択した自販機の商品名を取得する
            switch (selectVending)
            {
                // CocaCola
                case 1:
                    button = cocaCola.GetItem(itemName);
                    break;
                // Acure
                case 2:
                    button = acure.GetItem(itemName);
                    break;
                // Boss
                case 3:
                    button = boss.GetItem(itemName);
                    break;
            }
            return button;
        }


        /// <summary>
        /// 選択した自販機の商品を表示する
        /// </summary>
        /// <param name="selectVending">選択した自販機</param>
        private static void ItemNames(int selectVending = -1)
        {
            switch (selectVending)
            {
                case 1:
                    for (int i = 0; i < cocaCola.ItemNames.Count; i++)
                    {
                        showItemInfo(cocaCola.ItemNames[i], cocaCola.ItemPrices[i]);
                    }
                    break;
                case 2:
                    for (int i = 0; i < acure.ItemNames.Count; i++)
                    {
                        showItemInfo(acure.ItemNames[i], acure.ItemPrices[i]);
                    }
                    break;
                case 3:
                    for (int i = 0; i < boss.ItemNames.Count; i++)
                    {
                        showItemInfo(boss.ItemNames[i], boss.ItemPrices[i]);
                    }
                    break;
                default:
                    Console.WriteLine("1~3を入力してください");
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine("どれを買うか商品名を指定してください");
            Console.WriteLine("自販機を選び直す場合は「戻る」を入力してください");
            Console.WriteLine("----------");
        }

        /// <summary>
        /// 選んだ自販機で商品を購入する
        /// </summary>
        /// <param name="useVending"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        static KeyValuePair<string, int> Pyment(int useVending = -1, int button = -1)
        {
            // 所持金からお金を販売機に入れて購入
            var item = new KeyValuePair<string, int>();
            switch (useVending)
            {
                // CocaCola
                case 1:
                    item = cocaCola.Pyment(button, ref money);
                    break;
                // Acure
                case 2:
                    item = acure.Pyment(button, ref money);
                    break;
                // Boss
                case 3:
                    item = boss.Pyment(button, ref money);
                    break;
            }
            Console.WriteLine(item.Key + "を購入しました。");
            Console.WriteLine("残りの所持金は " + money + "円 です。");
            Console.WriteLine("");
            return item;
        }

        /// <summary>
        /// 商品と値段を表示する
        /// </summary>
        /// <param name="name">商品名</param>
        /// <param name="price">値段</param>
        private static void showItemInfo(string name, int price)
        {
            Console.WriteLine("商品名：" + name);
            Console.WriteLine("価格：" + price + "円");
            Console.WriteLine("----------");
        }

        private static void SelectStatus()
        {
            // 特定の飲料状態の商品を取得する準備
            Console.WriteLine("++++++++++");
            Console.WriteLine("「つめたい」飲み物は1");
            Console.WriteLine("「あったかい」飲み物は2");
            Console.WriteLine("「常温」の飲み物は3");
            Console.WriteLine("");

            // 特定の飲料状態を取得する
            var status = int.Parse(Console.ReadLine());

            switch (status)
            {
                case 1:
                    boss.NowStatus = Boss.DrinkStatus.cool;
                    break;
                case 2:
                    boss.NowStatus = Boss.DrinkStatus.hot;
                    break;
                case 3:
                    boss.NowStatus = Boss.DrinkStatus.normal;
                    break;
            }
        }
    }
}