using System.Collections.Generic;
//아래코드는 아직 배우지않아서 이해가 어려운 코드이니 어려우시면 제일 마지막에 분석하거나 건너뛰세요..
public static class StateFinderEX
{
    public static void AddState<Key, State>(this Key key, State state)
    where State : class, IStatable<object>
    {
        StateFinder<Key, State>.Add(key, state);
    }

    public static State GetState<Key, State>(this Key key)
    where State : class, IStatable<object>
    {
        return
        StateFinder<Key, State>.GetState(key);
    }

    public static class StateFinder<Key, State>
    {
        static Dictionary<Key, State> pairs = new();

        public static void Add(Key key, State state)
        {
            pairs.Add(key, state);
        }

        public static State GetState(Key key)
        {
            return
            pairs[key];
        }
    }
}