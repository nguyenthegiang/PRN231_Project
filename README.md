# For Team Member: Đọc kỹ nhé các bạn
## Sau Khi Pull Code:
 - Mở Powershell và chạy lệnh:  **dotnet ef database update**
## Sau khi Clone Project lại từ đầu:
 - Thêm file appsettings.json (xin các bạn khác) và chỉnh lại ConnectionString
 - (Nếu bạn đã xóa Database ở SQL Server): Chạy lệnh:  **dotnet ef migrations add "InitialDB"**
 - Mở Powershell và chạy lệnh:  **dotnet ef database update**
## Code:
 - Chỉ Code ở branch Main!!!
 - Hiện tại: chỉ cần code API, nếu cần demo xem thử thì có thể code tạm trong project WebClient (HTML-CSS-JS)
 - Nếu Sửa Database: Chạy 2 lệnh:
   +  **dotnet ef migrations add "InitialDB"**
   +  **dotnet ef database update**
 - Ghi chép lại sau khi code xong: theo như dưới đây:
## Process.docx:
 - Ở phần To Do: dùng để ghi lại những gì cần làm, mọi người có thể xem công việc mình cần làm ở đây
 - Ở phần Done: ghi lại những gì đã làm xong, sau khi code xong phần nào ở To Do thì chuyển nó xuống đây (cut & paste)
## Notes.docx:
 - Mô tả chi tiết những tính năng của Project, các chức năng mà chúng mình làm được,...
 - Sau khi Code xong tính năng gì thì các bạn ghi lại mô tả ở đây, có thể bao gồm:
    + Mô tả chức năng
    + Cách sử dụng
    + Cách thức hoạt động của chức năng (logic code...)
    
 ------------------------------------------------------------------------------------------------------------------------

# PRN231_Project
## Technology:
 - WebAPI: ASP.NET Core Web API 5.0
 - WebClient: HTML5 + CSS3 + Javascript (jQuery & AJAX)
## Functionality:
### Watch Video
