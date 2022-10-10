# Project_NetCoreAPI_MongoDB

Quá trình cài đặt và builder project:

-B1: Tạo project qua visual studio chọn .Net Core Web Api để tạo project.

-B2: Sau khi tạo xong, tạo file Startup là nơi config database, swagger, routing...

-B3: Cài đặt gói package MongoDB .Drive để tiến hành kết nối data, AutoMapper.

-B4: Tạo folder Services,Repository,Models,Dto.

-B5: Sau khi hoàn tất khởi chạy project

Công nghệ,ngôn ngữ:

-ngôn ngữ C#

-Cơ sở dữ liệu MongoDB

-MongoDB-Compass,GUI

-GitHub

-ASP.NET Core

Mô tả:

-Folder Services tạo các class là nơi để chứa các class xử lý logic, có thể gọi một hoặc nhiều repository.

-Folder Repositorys tạo các class là nơi để tương tác với database, class repository chịu trách nhiệm tương tác một entity tương ứng với database.

-Folder Dto tạo class là nơi có thể tùy chỉnh trả về dữ liệu khi thực hiện truy vấn để lấy dữ liệu trả về.

-Folder Models là nơi tạo các field dữ liệu để lưu vào database.

-Trong file appsettings.json config đường dẫn kết nối database MongoDb.

Quá trình tìm hiểu C#, .Net Core:

-Học cơ bản C# như tính kế thừa, các lớp class, namespace, interface...
https://xuanthulab.net/lap-trinh-c-co-ban/

-Tham khảo, đọc tài liệu về cách setup, build hệ thống .net core api trên microsoft, trên google.

-Tham khảo source trên github về .net core api.

-Đọc tài liệu MongoDB .NET Driver cách kết nối .Net Core với MongoDB, cách truy vấn dữ liệu thông qua MongoDB.
http://mongodb.github.io/mongo-csharp-driver/2.2/reference/driver/expressions/

-Tìm hiểu về package AutoMapper...

Ưu và nhược điểm của Nodejs và .Net Core:

-Nodejs: được viết bằng ngôn ngữ javascript nên cú pháp thoải mái, không gò bó nhưng dễ gặp lỗi nếu code ẩu và khó fix, hiển thị lỗi không rõ(nếu sử dụng typescript thì dễ fix lỗi, hiển thị rõ lỗi sai ở đâu). Cộng đồng lớn, nhiều gói package hổ trợ. Build dự án chạy nhẹ hơn. Sử dụng trong dự án vừa và nhỏ. Việc tạo swagger ui lâu hơn so với .net core.

-.Net Core: viết bằng ngôn ngữ C# cách khai báo cú pháp chặt chẽ hơn, hiển thị thông báo lỗi rõ ràng dễ fix hơn so với Nodejs, tính bảo mật cao, thường sử dụng trong dự án lớn. Build project nhanh hơn so với Nodejs,tự tạo swagger nhanh hơn, NodeJs phải cài đặt npm package về swagger. Tạo các file nhanh hơn,tự động import đường dẫn nhanh hơn so với NodeJs...

Kết quả:

Deploy Heroku

https://asp-netcore-api-mongodb.herokuapp.com/swagger/index.html
