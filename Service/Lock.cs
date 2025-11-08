namespace Service;

class Lock : IDisposable
{
    public class Flag
    {
        private int i_;
        public Flag()
        {
            i_ = 0;
        }

        // TODO: 別アセンブリでないと隠蔽にならない
        internal ref int I()
        {
            return ref i_;
        }
    }

    private Flag f_;
    private bool haveLocked_;
    // テスト
    public Lock(Flag f)
    {
        f_ = f;
    }

    public bool Try()
    {
        int result = Interlocked.CompareExchange(ref f_.I(), 1, 0);
        // 1が返る場合はすでに取得されていた
        if (result == 1) return false;
        haveLocked_ = true;
        return true;
    }

    public void Dispose()
    {
        if (haveLocked_)
        {
            Console.WriteLine(f_.I());
            Interlocked.CompareExchange(ref f_.I(), 0, 1);
            Console.WriteLine(f_.I());
        }
        haveLocked_ = false;
    }
}