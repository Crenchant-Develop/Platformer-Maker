using System.Collections.Generic;
//아래코드는 아직 배우지않아서 이해가 어려운 코드이니 어려우시면 제일 마지막에 분석하거나 건너뛰세요.

    //! 질문 : where문 관련해서 전반적인 설명이 필요함.
public static class StateFinderEX
{
    // 상태를 추가해주는 메서드.
    //! 질문 : state는 대충 알겠는데 key는 쓰신 의도가 뭔가요?
    public static void AddState<Key, State>(this Key key, State state)

    //!
    where State : class, IStatable<object>
    {
        StateFinder<Key, State>.Add(key, state);
    }

    //! 질문 : 이 메서드의 역할이 뭔가요?
    public static State GetState<Key, State>(this Key key)

    //! 질문 : 
    where State : class, IStatable<object>
    {
        return
        StateFinder<Key, State>.GetState(key);
    }

    // 현재 상태를 찾아주는 메서드.
    public static class StateFinder<Key, State>
    {
        //! 질문 : Dictionary 에 대한 설명 필요.
        static Dictionary<Key, State> pairs = new();

        // 
        public static void Add(Key key, State state)
        {
            pairs.Add(key, state);
        }

        // TODO
        public static State GetState(Key key)
        {
            return
            //! [Dictionary]
            pairs[key];
        }
    }
}