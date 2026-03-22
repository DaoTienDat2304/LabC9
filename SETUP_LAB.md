# Lab 1–6: Setup đầy đủ & gợi ý chụp màn hình báo cáo

Code mẫu nằm trong `Assets/Scripts/Lab/`. Làm theo thứ tự dưới đây.

---

## Chuẩn bị chung (làm một lần)

1. Mở project Unity (`LabC9`).
2. Tạo folder `Assets/Scenes` (nếu chưa có).
3. Tạo **2 scene**:
   - **File → New Scene** → **Save As…** → `Assets/Scenes/Menu.unity`
   - **File → New Scene** → **Save As…** → `Assets/Scenes/Game.unity`
4. **File → Build Settings** (`Ctrl+Shift+B`): **Add Open Scenes** cả hai scene; **Menu** kéo lên **trên** **Game** (scene 0 = scene chạy đầu khi build).

**Ảnh báo cáo (chung):** Build Settings: thấy 2 scene `Menu`, `Game` và thứ tự đúng.

---

## Lab 1 – Static truyền dữ liệu giữa scene

**Ý:** `SceneData.ScoreToCarry` là static; gán ở Menu, đọc ở Game.

**Setup**

- Scene **Menu**: Empty `MenuRoot` → Add Component **`MenuController`**.  
  - `Game Scene Name` = `Game` (trùng tên file scene Game).
- Scene **Game**: Empty `GameRoot` → Add Component **`GameController`**.
- Scene **Menu**: (UI) **GameObject → UI → Button**, chọn Button → **Button (Script)** → **On Click ()** → `+` → kéo object có `MenuController` → chọn **`MenuController → OnButtonPlay`**.

**Chạy:** Mở scene **Menu** → Play → bấm nút → sang scene Game.

**Ảnh nên chụp**

| # | Nội dung |
|---|----------|
| 1 | Inspector **MenuController**: thấy `Score To Pass` (ví dụ 100), `Game Scene Name` = Game. |
| 2 | **Console** sau khi vào Game: dòng `[Lab1] SceneData.ScoreToCarry = ...` khớp số đã gán. |
| 3 | (Tuỳ chọn) Mở `SceneData.cs` trong IDE, chụp đoạn `public static int ScoreToCarry`. |

---

## Lab 2 – DontDestroyOnLoad (GameManager)

**Ý:** `GameManager` gắn `DontDestroyOnLoad`, không bị hủy khi `LoadScene`.

**Setup**

- Trên scene **Menu**: Empty tên **`GameManager`** → Add Component **`GameManager`** (script singleton, một instance).

**Chạy:** Play từ Menu → bấm Play vào Game → Console có log Lab 2.

**Ảnh nên chụp**

| # | Nội dung |
|---|----------|
| 1 | Hierarchy scene **Menu**: thấy object `GameManager` + component **GameManager** trong Inspector. |
| 2 | **Console**: dòng `[Lab2] Có GameManager (DontDestroyOnLoad).` |
| 3 | (Tuỳ chọn) Mở `GameManager.cs`, chụp `DontDestroyOnLoad(gameObject)`. |

---

## Lab 3 – PlayerPrefs HighScore

**Ý:** `HighScorePrefs.Get()` / `TrySave()` dùng `PlayerPrefs.SetInt` / `GetInt`.

**Setup:** Không cần thêm object — `GameController` đã gọi trong `Start()`.

**Chạy:** Vào Game (sau khi bấm từ Menu); xem Console: `[Lab3] HighScore (trước)` / `(sau)`.

**Ảnh nên chụp**

| # | Nội dung |
|---|----------|
| 1 | **Console** đầy đủ 2–3 dòng Lab 3 (trước/sau khi lưu). |
| 2 | (Tuỳ chọn) Code `HighScorePrefs.cs`: `SetInt`, `GetInt`, `Save()`. |

**Ghi chú:** `PlayerPrefs` lưu trên máy; muốn “reset” điểm thử: **Edit → Clear All PlayerPrefs** (khi đang Play hoặc tùy phiên bản Unity).

---

## Lab 4 – JSON (JsonUtility)

**Ý:** Class `PlayerData` + `JsonUtility.ToJson` / `FromJson`.

**Setup:** Đã có trong `GameController` + `PlayerData.cs`.

**Chạy:** Console có `[Lab4] JSON:` và chuỗi JSON.

**Ảnh nên chụp**

| # | Nội dung |
|---|----------|
| 1 | **Console**: khối log JSON (có `playerName`, `level`, `score`). |
| 2 | `PlayerData.cs` với `[Serializable]` và các field `public`. |

---

## Lab 5 – ScriptableObject GameConfig

**Ý:** Thông số game nằm trong asset, không hard-code.

**Setup**

1. Chuột phải **Project** (ví dụ `Assets`) → **Create → Lab → GameConfig**.
2. Đặt tên `GameConfig` (hoặc tùy ý), chỉnh **Max Lives**, **Move Speed** trên asset.
3. Scene **Game**: chọn object có **GameController** → Inspector → kéo asset **GameConfig** vào ô **Config**.

**Ảnh nên chụp**

| # | Nội dung |
|---|----------|
| 1 | **Project**: icon ScriptableObject **GameConfig** + Inspector asset (maxLives, moveSpeed). |
| 2 | **GameController** Inspector: ô **Config** đã gán asset. |
| 3 | **Console**: `[Lab5] GameConfig → maxLives=..., moveSpeed=...`. |

---

## Lab 6 – File save (persistentDataPath)

**Ý:** `File.WriteAllText` / `ReadAllText` dưới `Application.persistentDataPath`.

**Setup:** Dùng `FileSaveJson` — `GameController` đã gọi `Save` / `LoadOrNew`.

**Chạy:** Console có `[Lab6] Đường dẫn: ...` — copy đường dẫn, mở Explorer và (nếu có) mở file `playerdata.json` để thấy nội dung JSON.

**Ảnh nên chụp**

| # | Nội dung |
|---|----------|
| 1 | **Console**: dòng đường dẫn file + log đọc được `playerName`, `score`. |
| 2 | **Windows Explorer**: folder `persistentDataPath` + file `playerdata.json` (hoặc mở Notepad nội dung file). |
| 3 | (Tuỳ chọn) `FileSaveJson.cs`: `Path.Combine`, `Application.persistentDataPath`, `File.WriteAllText`. |

**Đường dẫn thường gặp (Windows):**  
`C:\Users\<TênUser>\AppData\LocalLow\<CompanyName>\<ProductName>\`  
(Company/Product trong **Edit → Project Settings → Player**).

---

## Checklist chụp nhanh (đủ 6 lab)

1. **Build Settings** – 2 scene.  
2. **Menu** – MenuController + (nút UI nếu có).  
3. **Menu** – GameManager trên Hierarchy.  
4. **Game** – GameController + GameConfig gán trong Inspector.  
5. **Console** – một lần Play: crop hoặc chụp dài để thấy `[Lab1]` … `[Lab6]`.  
6. **Project** – asset GameConfig.  
7. **File** – Explorer + `playerdata.json` (Lab 6).

---

## Gợi ý cách chụp cho đẹp

- **Unity Editor:** `Window → General → Console` — bật rõ **Info** (không lọc hết log).  
- Chụp **Full Editor** (Scene + Game + Inspector + Console) hoặc **chỉ Console** zoom font (Unity: góc Console có thể resize).  
- Hoặc dùng **Snipping Tool** / **Win+Shift+S** chọn vùng Console có đủ log Lab 1–6.  
- Báo cáo Word/PDF: mỗi lab 1–2 ảnh (Inspector + Console hoặc code + kết quả) là đủ nhập môn.
