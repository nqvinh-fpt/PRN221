<script src="~/lib/usersCount.js"></script>
<script>
    // Thiết lập kết nối SignalR
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/eventHub") // Địa chỉ của SignalR Hub
        .build();

    // Khởi tạo kết nối SignalR
    connection.start().then(function () {
        console.log("SignalR Connected");
    }).catch(function (err) {
        return console.error(err.toString());
    });

    // Lắng nghe sự kiện "updateAttendeeCount" từ server
    connection.on("updateAttendeeCount", function (eventId, attendeeCount) {
        // Tìm và cập nhật số lượng người tham dự trên trang
        var attendeeCountElement = document.getElementById("attendeeCount_" + eventId);
        if (attendeeCountElement) {
            attendeeCountElement.textContent = attendeeCount;
        }
    });
</script>