# Setup đúng ý: log nằm trong file sẵn có

Bạn KHÔNG cần tạo 6 script logger nữa. Log đã nằm trực tiếp trong các file:
- `MenuController` (Lab 1)
- `GameManager` (Lab 2 + điều phối Lab 3/4/5/6 khi vào scene Game)
- `HighScorePrefs` (Lab 3)
- `FileSaveJson` (Lab 4 + Lab 6)
- `GameConfig` (Lab 5)

## 1) Tạo scene
1. Tạo `Menu` và `Game` trong `Assets/Scenes`
2. `File -> Build Settings` add cả 2 scene (Menu trước, Game sau)

## 2) Setup scene Menu
1. Tạo Empty `MenuRoot` -> gắn `MenuController`
2. (Tuỳ chọn) Tạo Button, OnClick gọi `MenuController.OnButtonPlay`
3. Tạo Empty `GameManager` -> gắn `GameManager`
4. Tạo asset `GameConfig`:
   - Project -> Right click -> `Create -> Lab -> GameConfig`
   - Chọn object `GameManager`, kéo asset `GameConfig` vào field `Game Config`
   - Chọn object `MenuRoot`, kéo asset `GameConfig` vào field `Game Config`

### Cau hinh diem cho button (theo yeu cau)
- Uu tien chinh trong asset `GameConfig`:
  - `Score Per Click` (vi du 20/30/40)
  - `Score To Pass` (vi du 200)
- `MenuController` van co `Score Per Click` va `Score To Pass` lam fallback neu ban chua gan `GameConfig`.
- Button van goi `OnButtonPlay`, nhung gio no se:
  1) cong diem,
  2) save HighScore (Lab 3),
  3) save JSON (Lab 4/6),
  4) chi load scene `Game` khi du 100.

## 3) Chạy
1. Mở scene `Menu`
2. Play -> bấm nút để sang scene `Game`
3. Mở Console sẽ thấy log Lab 1 -> Lab 6 tự động

## 4) Log nào nằm ở đâu
- Lab 1: log ở `MenuController.OnButtonPlay()`
- Lab 2: log ở `GameManager.Awake()`
- Lab 3: log ở `HighScorePrefs.Get()` và `TrySave()`
- Lab 4: log ở `FileSaveJson.Save()` và `LoadOrNew()` (ToJson/FromJson)
- Lab 5: log ở `GameConfig.DebugLog()` (được `GameManager` gọi)
- Lab 6: log ở `FileSaveJson.Save()` và `LoadOrNew()` (đường dẫn file)
