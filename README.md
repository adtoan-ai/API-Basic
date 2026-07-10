# Tài liệu Hướng dẫn kết nối API Quản lý Sản phẩm

## 1. Thông tin chung
- API được xây dựng bằng ASP.NET Core.
- Base URL (địa chỉ chạy local): `https://localhost:7030`

## 2. Hướng dẫn Front-end (Web/Mobile) kết nối API

Tài liệu này sử dụng JavaScript (`fetch` API) để minh họa cách giao tiếp với Backend. Bạn có thể áp dụng mã nguồn này trực tiếp vào các dự án web Front-end (như trang web quản lý cửa hàng) bằng cách nhúng vào các thẻ `<script>`.

### A. Thêm mới sản phẩm
- **Endpoint:** `POST /api/products`
- **Mô tả:** Thêm một sản phẩm mới vào hệ thống.
- **Dữ liệu yêu cầu (Body JSON):**
  - `name`: Chuỗi, bắt buộc, tối thiểu 3 ký tự.
  - `price`: Số, bắt buộc, lớn hơn 0.

**Ví dụ code gọi API:**
```javascript
const addProduct = async () => {
    const data = {
        name: "Bàn phím cơ",
        price: 500000
    };

    try {
        const response = await fetch('https://localhost:7030/api/products', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        const result = await response.json();

        if (!response.ok) {
            console.error("Dữ liệu không hợp lệ:", result.errors);
        } else {
            console.log("Thêm thành công, ID sản phẩm là:", result.id);
        }
    } catch (error) {
        console.error("Lỗi kết nối server:", error);
    }
};
