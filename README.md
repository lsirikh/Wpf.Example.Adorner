# PIDS Monitoring Program
## Site : Daedeok SK

### Update Date: 2022/06/13
* Version : v2.5.6
* 기능: 
1) 적외선 접점 출력 기능 설정
2) 환경설정 접점 관련 내용 삭제
3) 사이렌 관련 기능 삭제

### Update Date: 2022/06/13
* Version : v2.5.6
* Ironwall.Thirdparty.VMS 
1) LoginTimer 기능 구현
    - 정해진 시간에 따라 VMS Api Logout -> Login
    - 기존에 이벤트 쏘고 Logout 되던 구조에서 Keep Alive 형태로 변경
        (PTZ 다시 원위치 시키는 문제로 인해서...)

2) VcaService
    - 각 Response 객체로 받을 수 있도록 구현 Class화시킴
    - PTZ 지정된 시간에 원위치로 돌아오는 기능 구현
    - 조치보고 후, 지정된 시간만큼 있지않고, 바로 돌오아오는 기능 구현

* 추후 확인할 사항(VMS업체와 회의 시)
1. 프리셋 설정 역할
2. VMS 프리셋 연동 방법
    1) 센서웨이에서 이벤트 번호를 주면 해당 이벤트 번호에 맞는 매칭되는 카메라 프리셋을 돌리고 팝업을 띄운다.
        
        ㄱ. 센서웨이에서 이벤트 번호를 보내주는 로직을 구현 후 VMS어디로 보낼지 정해져야됨
        
        ㄴ. 통신 방법은 어떤것으로 할지 정해야됨(TCP 소켓으로 할지 등)

    2) 센서웨이에서 카메라 프리셋을 돌리고, 상황이 끝나면 원래위치로 돌린다.
        
        ㄱ. 현재 Vca 팝업을 띄우면, 다른 화면이 안올라가는 문제가 있음
        
        ㄴ. 현재 Vca 팝업을 하고 PTZ를 돌려야만 하는 문제 
        
        ㄷ. PTZ 팝업이 된 상태에서 다른 Vca 팝업 이벤트가 나타나면, 이전 PTZ 이벤트가 자동으로 복귀되는 문제
        
        ㄹ. 로직 협의가 필요.


### Update Date: 2022/07/19
* Version : v2.6.0

* Ironwall.Monitoring.UI
    1. SetupPanelViewModel 통합 및 분리

        ㄱ. 기존 SetupPanel Inner ViewModel정보 ContentControl로 분리 구성

        ㄴ. 각종 외부 연동 기능 설정 구현

        ㄷ. CameraSetting 부분 추가

        ㄹ. Camera Preset 설정 부분 추가

        ㅁ. SendMessage 설정 부분 추가

* Ironwall.Libraries.Utils
    1. 프로젝트 분리 및 정리

* Ironwall.Libraries.Enums
    1. 프로젝트 분리 및 정리

* Ironwall.Libraries.RTSP
    1. RTSP 스트리밍을 위해서 개발된 라이브러리
    2. 사용 Nuget Package - RtspClientSharp, Onvif.Solution 사용
    3. 일부 카메라에 스트리밍 오류(계정인증오류)에 관한 버그가 있어 직접 디버깅하여 프로젝트를 레퍼런싱하여 빌드

        1) 기능

            ㄱ. 카메라의 RTSP 데이터를 트랜스코딩하여 실시간 View를 제공(단, H.264, M-JEPG 형식만 가능)
            
            ㄴ. Onvif 프로토콜을 이용한 카메라 Preset Control 가능

            ㄷ. Control Time 속성을 활용한 Target preset과 Home preset 간 Traverse


* Ironwall.Framework
    1. 프로젝트 분리 및 정리
    2. BaseDataGridViewModel 생성
        1) 기존에 DataGridViewModel 계열의 작업 시, 반복되는 업무를 abstract 타입으로 상위 개념자로 뽑아냄

        2) 재사용성을 극대화 하고, 반복 작업은 최소화

* Ironwall.Thirdparty.VMS
    1. v2.5.6에서 개발한 VCA이벤트 방식이 실제 사업 영역에서는 불필요한 기능으로 파악되어, 과감하게 Deprecated
    2. 현재는 카메라 팝업을 위한 버전으로 업데이트하여, 카메라에 Onvif 연동이 어려울 경우 이노뎁 VMS를 통한 PTZ 컨트롤
        1) 로직
            
            ㄱ. 탐지 정보를 확인 후, RTSP 라이브러리에서 제공하는 카메라 정보, 프리셋 정보를 의존함
            
            ㄴ. RTSP 라이브러리에서 제공해주는 카메라 이름 정보로 Vca Camera 리스트와 매칭한다.
            
            ㄷ. 매칭된 정보를 통해서 Vurix Api와 연동하기 위한 카메라 시리얼 및 채널을 확보 한 후, API를 통한 PTZ 제어 메시지 전송
            
            ㄹ. Cancellation token이 발생하거나, 지정된 시간만큼이 지나면 복귀 PTZ 제어 메시지 전송

### Update Date: 2022/07/21
* Version : v2.6.5

* Ironwall.Monitoring.UI
    
    1. DomainService Task Method 로 분리

        ㄱ. CameraPopup Task, SirenCall Task, SendMsg Task 등 Method 분리

    2. 이벤트 카드에서 해당 이벤트의 카메라 팝업 호출 기능 구현 증평 관제 왕문식 수석 요청사항

    3. 대덕 요구사항 전부 통합 구현 완료

        ㄱ. Siren(경광등) 기능 전부 복원

        ㄴ. SensorFusion 기능 Inactivated 상태로 전환


### Update Date: 2022/07/28
* Version : v2.7.5

* Ironwall.Monitoring.UI

    1. RTSP의 streaming library를 VLC 라이브러리로 교체

        ㄱ. VLC Control과 관련된 소스가 UI에 통합되어 있어서 발려내는 작업이 필요함

        ㄴ. 연속적인 카메라 팝업 요청시 프로그램이 죽는 현상의 개선이 필요함

        ㄷ. 속도의 최적화가 필요함

    2. Watchdog 기능 적용이 되었으나, 동작상 원할하지 않은 문제가 발생

        ㄱ. Setting panel에 watchdog on/off 기능이 필요.

        ㄴ. Setting panel에서 watchdog activate/kill button 필요

    3. Siren 개별 on/off 기능은 적용이 되나 db에 동일한 namearea를 갖는 복수개의 레코드가 존재할 경우 버그 발생

    4. 0.2초 사이로 데이터가 입력되는 경우 프로그램 먹통이 되는 현상이 발생

    5. 프로그램이 죽는 경우 watchdog으로 살아날 경우 자동 로그인 적용 요청 확인


### Update Date: 2022/08/02
* Version : v2.7.6

* Ironwall.Monitoring.UI

    1. Watchdog setting Panel에서 활성화/ 비활성화 가능하고, 버튼으로 켜고/끄는 기능 제공


### Update Date: 2022/08/03
* Version : v2.7.7

* Ironwall.Monitoring.UI

    1. RTSP의 streaming library의 동작 관련 이슈 처리

        ㄱ. 최대 연속 팝업 호출 스트레스 테스트(약 0.5s 이하로 연속 호출 시, 오류 없이 작동 확인)

        ㄴ. debug console로 나오는 메세지 확인(Delegate로 메시지 구분)

        ㄷ. 프로그램 종료 시, Vlc 기반의 오류 메시지 처리(Dispose 처리)

    2. Watchdog의 process kill기능이 컴퓨터별로 다르게 동작하는 원인 확인

        ㄱ. 관리자 권한으로 프로그램 실행을 통한 외부 프로세스 제어(실행/종료)

    3. Siren(ContactViewModel) 세부 제어를 위한 LINQ 수정

        ㄱ. Siren preset의 복수 nameArea 레코드 존재 시, 그룹1, 그룹2, 이런식으로 구분지어 놓음

### Update Date: 2022/08/11
* Version : v2.7.8

* Ironwall.Monitoring.UI

    1. 중복 카메라 시현 로직 수정

        ㄱ. IsOnPopup 변수 적용 및 CheckPopup Task 수정

    2. 카메라 팝업 View 수정
    
        ㄱ. 버튼 타입 수정

        ㄴ. 창 확대 축소 가능 수정

### Update Date: 2022/11/08
* Version : v2.7.9

* Ironwall.Monitoring.UI

    1. 카메라 새로운 Onvif라이브러리 Mictlanix.DotNet.OnvifClient v0.0.3 적용

    2. 테스트

    3. DiscoveryDevice 버그 수정