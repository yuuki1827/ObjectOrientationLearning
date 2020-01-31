using System;
using System.Collections.Generic;

// 【オーバーライド/オーバーロードのメリット】
//     ・親クラスの機能をコントロールできる
//     ・メソッドのリサイクルで不要なメソッドが生まれない
//     ・同じメソッドで、振る舞いは同じでも細かい追加処理ができる

namespace ObjectOrientationLearning
{
    /// <summary>
    /// アキュアの自販機クラス
    /// </summary>
    public class Acure : VendingMachine
    {
        /// <summary>
        /// 飲み物の個数を管理
        /// </summary>
        List<int> _itemCounts;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Acure() : base("アキュア")
        {
            _itemCounts = new List<int>();

            AddItem("お茶", 150, 10);
            AddItem("ミネラルウォーター", 110, 20);
            AddItem("ラムネ", 120, 10);
        }

        /// <summary>
        /// 継承するために使用されるコンストラクタ
        /// </summary>
        protected Acure(String name) : base(name)
        {
            _itemCounts = new List<int>();

            // ※AddItemは継承先の子クラスで用意すること
        }

        /// <summary>
        /// 商品を追加する
        /// </summary>
        protected void AddItem(String name, int price, int count)
        {
            base.AddItem(name, price);
            _itemCounts.Add(count);
        }

        /*
         * 【「GetItem」他3つのwarningについて】
         * 大雑把に言うと、
         * 「継承先の変数とか関数とかが継承元の同名のやつとダブってるけどそのままでいいの？」
         * ということらしい。
         * この「Acure」クラスは「VendingMachine」クラスを継承しており、
         * 「Acure」クラスは「VendingMachine」クラスのGetItemメソッド(133行目)を使用できる。
         * だが、以下のコードでは「Acure」クラスでもGetItemメソッドを作成している。
         * それでは「GetItem();」と記述した場合、どちらのGetItemメソッドなのか区別がつかない状態となる。
         * 
         * 「GetItem();」で実行した場合、新しく定義した「Acure」クラスのGetItemメソッドが実行され、
         * 「VendingMachine」クラスのGetItemメソッドは実行されない。
         * 「base.GetItem();」とすることで、VendingMachine」クラスのGetItemメソッドを呼び出すことができる。
         *
         * 「Acure」クラスGetItemメソッドの開始を「public」→「new」にすることで
         * VendingMachine」クラスのGetItemメソッドを使う気がないとコンパイラにアピールでき、
         * 警告を消すことができる。(public new ~ の方が表記としては正しいのかもしれない)
         *
         * 「public override ~」にすることでも警告を消すことができる。
         * その場合、継承元には「public virtual ~」と指定する必要がある。
         */
        /// <summary>
        /// 商品の場所（添字）を取得する
        /// </summary>
        public override int GetItem(String name)
        {
            var index = base.GetItem(name);

            if (index != -1 && _itemCounts[index] < 1)
                return -1;  // 売り切れ

            return index;
        }

        /// <summary>
        /// 商品を買う
        /// </summary>
        public override KeyValuePair<string, int> Pyment(int index, ref int money)
        {
            var product = base.Pyment(index, ref money);

            if (product.Key != null)
                _itemCounts[index]--;

            // nullを返却
            return product;
        }
    }
}
