# Name：DogKnight
 
# プレイ画面（GIF）
 ## 画面遷移
 ![Screen_transition](https://user-images.githubusercontent.com/125266372/223749680-060a4941-6a74-411e-b3c4-6f5cef93c452.gif)
 ## 戦闘風景
 ![Fight_sample](https://user-images.githubusercontent.com/125266372/223749972-21caf639-6bd7-48d8-a170-e46912de15fa.gif)
 ## 勝利画面
 ![Win_sample](https://user-images.githubusercontent.com/125266372/223750029-4004e5b6-e878-4f52-8dc2-09d31694addc.gif)
 
 
 
# 特徴
前作"Dog_Knight"の知識・反省を生かして製作に取り掛かる  
↓前作"Dog_Knight"のURL  
https://github.com/s-mas01/Dog_Knight.git

・Asset選び  
・曲選び  
・SE選び  
・コード製作  
・デバック  
### 全て私自身が選別・製作しました。


## 前作"DogKnight"からの変更点
[前作:Dog_Knight]  
出先や移動中に遊ぶことを想定して製作  
にWキー：前進　Sキー：後退　Aキー：左旋回　Dキー：右旋回  Eキー：スキル（薙ぎ払い）マウス操作は左クリックで攻撃だけにした。

[今作:Dog_Knight2]  
腰を据えて遊べることを想定して製作  
WASDで移動  Eキー：スキル（薙ぎ払い）マウス操作は左右の視点操作と左クリックで攻撃




# 工夫点
* アニメーションにフレーム単位でイベントを付け当たり判定などを制御
![game_create](https://user-images.githubusercontent.com/125266372/223724200-6744840f-2b55-4c0b-b644-82b462000def.png)

* プログラムが分からなくても簡単にPlayerのステータスを変えられる
![game_create1](https://user-images.githubusercontent.com/125266372/223724721-9f2425b5-89bd-4288-a1be-32619823b621.png)

* プログラムが分からなくても簡単にEnemyのステータスを変えられる、敵のステータスはリストで一括管理
![game_create2](https://user-images.githubusercontent.com/125266372/223724765-1cae52b6-128a-4528-b1f1-29dc290f6b00.png)



# ソースコードの場所  
Assets　-> Scripts  
その中のファイリングされてれている物です。

 ## Enemy  
 -- Animation(敵のアニメーション中の動作の制御)  
 -- Manager　（ゲーム画面での敵の動きの制御)  
 
 ## Game System 
 --Status(Player Enemyのステータス管理)  
 CameraController(ゲームの視点のカメラ管理)  
 ClearManager　（ゲームクリア条件の管理）  
 LookAtCmamera　（敵のHPなどのUIがPlayeのカメラを向くように制御）  
 TitleScreanManger（画面遷移の管理)  
 
 ## Player
  -- Animation(Playerのアニメーション中の動作の制御)  
 -- Manager　（ゲーム画面でのPlayerの動きの制御）  


製作：Unity 2021.3.16f1
 
# 使用機器　OS
 
windows intel 64-bit

# ダウンロードからゲーム起動まで
![DL1](https://user-images.githubusercontent.com/125266372/221795491-47046d01-17a9-494f-bdb0-930642e15994.png)
1. <>CodeのプルダウンよりDownload ZIPを選択しファイルをダウンロードする。  
2. ZIPを解凍する。  
3. ファイル内の"DogKnight.exe"をダブルクリックしてアプリを起動する。  

# メモ
RPGにある程度必要そうな要素は盛り込んだがまだ設定画面やアイテムの実装が出来ていない。  
クリアに関する条件の部分のコードも雑で変更が容易でなく改善の余地が過分にある。  
（ゆくゆくは別のコードにまとめて関数として呼び出すつもり。）

# 製作者
作成者：白鳥雅也  
所属　：山梨大学 メカトロニクス工学科 

# サンプル画面
* Title  
![Title1](https://user-images.githubusercontent.com/125266372/223723400-a5edd2bd-49f4-496d-9ef6-b73f2b221e6b.png)

 * How To
![HowTo1](https://user-images.githubusercontent.com/125266372/223723629-6498f75c-f92c-4777-9a5a-f31dc0e6c072.png)
 
 * Object
![Object](https://user-images.githubusercontent.com/125266372/223723755-d1208793-531b-40c5-af57-78b87002e397.png)

 * PIckMap
![PickMap1](https://user-images.githubusercontent.com/125266372/223723923-ffd7983b-e55e-4b0f-9f5a-ad30d637c6f5.png)

 * Game Screan
![GameScrean](https://user-images.githubusercontent.com/125266372/223724050-8eeefd02-549f-456e-bf13-47c49497100a.png)

 
