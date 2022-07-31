//상속해서 T타입을 구체화함. 추후에 확장되어 다른 기능이 추가될 수 있으나, 현재는 아직 비어놓아도 상관없다고 판단함.
interface IMotionConnectable : IStateConnectable<MotionalState>, IMotionable
{
}
