using UnityEngine;

//유니티에서는 일반 C# 상식이 안통하는 것이 존재한다
//유니티에서 MonoBehaviour를 상속받은 타입은 new 키워드로 인스턴스를 만들지 못한다.
//Test타입은 MonoBehaviour를 상속받고 있다.
class Test : MonoBehaviour, IAction
{
    // 1. aceess modifier을 적지 않는다.
    // 2. <인터페이스 이름>.<메소드 이름> 의 포맷을 가진다.
    //IAction 인터페이스 명시적 구현 메소드
    void IAction.Invoke<T, State>(T controller)
    {
        Debug.Log("나는 인터페이스 IAction타입");
    }

    //IAction 인터페이스 일반 구현 메소드
    public void Invoke<T1, T2>(T1 controller) where T1 : IController<T2>
    {
        Debug.Log("나는 테스트 클래스 타입");
    }

    // 객체가 생성된 후 Awake를 유니티가 호출해준다.
    // 따라서 상대적으로 자기 자신을 의미하는 this는 유효하다.
    // 여기서의 this는 유니티 컴포넌트 객체를 의미한다
    private void Awake()
    {
        //Destroy(this); // UnityEngine.Object를 상속받고 있는 객체를 죽이는거고 (예를들어 게임오브젝트의 스크립트 하나를 삭제할 수 있음)
        //Destroy(gameObject); //게임오브젝트를 죽이는 것. (모든 스크립트 객체가 다 죽어버림)

        // 기본적으로 자식 타입 객체는 부모타입으로 암시적 타입 캐스팅(형변환)이 가능하다.
        // this의 타입은 Test인데 이 Test라는 클래스가 IAction을 상속받고 있기 때문에 오류가 나지 않는다.
        // 명시적 구현 메소드는 인터페이스 부모타입으로 타입캐스팅 된 객체일때만 호출 할 수 있다.
        Test  test1 = this;
        test1.Invoke<PlayerController, Vector2>(new PlayerController());

        //이게 형변환
        IAction test2 = test1;
        test2.Invoke<PlayerController, Vector2>(new PlayerController());
    }
}
