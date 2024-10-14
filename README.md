# 유한 도구 (Yuhan Tool)

유한 도구는 C#으로 개발된 유틸리티 모음 프로젝트입니다. 주로 Windows Forms 애플리케이션과 캡처 도구 등 다양한 기능을 포함하고 있습니다.

## 프로젝트 구조

- **WindowsFormsRec**: 화면 녹화 도구.
  - **화면 녹화 기능**: 30 FPS로 화면을 녹화하고, H264 코덱을 사용하여 MP4 형식으로 저장합니다.
  - **녹화 시작/중지**: 버튼 또는 `Ctrl + R` 단축키로 녹화 제어.
  - **저장 경로 설정**: 녹화 파일을 저장할 폴더를 선택할 수 있습니다.
  - **실시간 상태 표시**: 현재 녹화 상태를 UI에 표시합니다.
  - **멀티 스레드 지원**: 녹화 중에도 UI가 멈추지 않습니다.
- **Drawing**: 그림판 도구.
- **Capture**: 화면 캡처 도구.
- **Notepad**: 메모장 도구.

## 결과물
- 메인
![image](https://github.com/user-attachments/assets/ffbbfac0-3225-4e00-b269-5b6653da1a90)
- 녹화
![image](https://github.com/user-attachments/assets/eb6e93bb-03d7-437a-a76b-ae24d799f31f)
- 메모장
![image](https://github.com/user-attachments/assets/a76f4064-a0e0-4efe-ab8d-4188769a07d9)
- 그림판
![image](https://github.com/user-attachments/assets/41eb7f5b-e99f-42e4-b2a7-8a6dc5168148)

