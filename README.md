# WPF Shape Element Adorner
## Project : Example

<hr>

### Update Date: 2023/03/27  
  
* Project : Wpf.Example.Adorner  
* Version : v1.0.0  
* 기능:  
  1) Shape Element - Rectangle Based Adorner Control    
  2) 총 8개의 포인트를 이용하여 사이즈 조정  
  3) Code-behind 형태로 구현하여 기능위주로 테스트    
   
* Project : Wpf.Example.OnCanvas.Adorner    
* Version : v1.0.0  
* 기능:  
  1) Canvas 상에서 Shape Element를 컨트롤하는 기능을 구현한다.  
  2) Shape의 Control은 기존 프로젝트 Wpf.Example.Adorner을 기반으로 구축한다.  
  3) Canvas 상에서 이동을 위한 Control을 구성한다. 추가적인 Adorner가 될 수 있다.  
  
<hr>

### Update Date: 2023/03/28  
  
* Project : Wpf.Example.OnCanvas.Adorner    
* Version : v1.0.0  
* 기능:  
  1) 미완성된 adorner 컨트롤을 추가적으로 구현한다.  
   

* Project : Wpf.Example.OnCavas.RotateAdorner    
* Version : v1.0.0  
* 기능:  
  1) 불완전하지만, Circle Adorner element를 이용하여, Canvas 상의 Rectangle 요소를 회전 시킬 수 있다.  
  2) 회전과 함께 Adorner element는 회전 동기가 되지만, 사용자의 요구에 맞게 회전 각도가 변경이 안된다. 이 부분은 삼각함수를 이용해서 각도계산이 필요할 것으로 보인다. 마우스 이동에 따른 회전 각도 계산을 위한 로직 구현이 필요하다. 현재 일부 요소가 적용되었지만, 완벽하지 않은 부분을 감안해서 수정작업이 필요하다.  
  3)   