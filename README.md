# 🎮ReplaceModelForEVMC4U
![RM4EVMC4U_non](https://user-images.githubusercontent.com/59566441/90384044-ee50cb80-e0bb-11ea-8555-45a0806dffd7.png)  
[EVMC4U](https://github.com/gpsnmeajp/EasyVirtualMotionCaptureForUnity)で何故かEnable Auto Load VRMオプションを使いたくない人向けのVRM切り替えスクリプトです。  
[TeleportKit](https://github.com/gpsnmeajp/EasyVirtualMotionCaptureForUnity/wiki/TeleportKit)や[シネスイッチャー](https://booth.pm/ja/items/1654878)の使用を考慮したスクリプトになっています。  
注：バーチャルモーションキャプチャーで読み込むVRMとボーン構造が一致したVRMを使用して下さい。  
　　具体的には、素体は同一で服だけ違うVRMの切り替えなどに使用して下さい。  
 
# 🎙ご説明
![RM4EVMC4U](https://user-images.githubusercontent.com/59566441/90384451-8353c480-e0bc-11ea-8c40-9b916a947e01.png)
 
ReplaceModelForEVMC4Uを適当なGameObjectにアタッチして使用して下さい。設定は画像の通りです。  
  
シネスイッチャーを使用していない場合、using Cinemachine周りでエラーを吐きますので、  
Cinemachineを導入しエラー回避してください。  
もしくはスクリプトを書き換えてご対応下さい。書き換え（コメントアウトor削除）箇所は以下のとおりです。  
```
1  using Cinemachine;  
10 public Transform[] ModelTransesHead = new Transform[2];  
11 public CinemachineVirtualCamera[] VCams = new CinemachineVirtualCamera[2];  
84 for (int j = 0; j < VCams.Length; j++)
85 {
86   VCams[j].LookAt = ModelTransesHead[a];
87 }
```
 
また、以下、各変数の箇条書きでの補足です。

* External Receiver：External ReceiverのGameObject指定  
* Teleport Manager：[Teleport Manager](https://github.com/gpsnmeajp/EasyVirtualMotionCaptureForUnity/wiki/TeleportKit)のGameObject指定  
* Models：VRMモデルの数、GameObject指定  
* Model Transes Head：[シネスイッチャー](https://booth.pm/ja/items/1654878)(Cinemachine)のLookAtに指定したいVRMモデルの数、ボーン指定  
* V Cams：[シネスイッチャー](https://booth.pm/ja/items/1654878)(Cinemachine)でLookAtを使用しているカメラの数、CM vcam指定  
* Input Key：VRMモデルの数、切り替えキー指定  
 
# 👽作者  
 
* [大福らな](https://www.youtube.com/channel/UCtg9i4TxyddG5QV5CYZETiQ)
* [pachelam.com](https://pachelam.com/)
* [@daifuk_lana](https://twitter.com/daifuk_lana)
 
# License
 
"ReplaceModelForEVMC4U" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).
 