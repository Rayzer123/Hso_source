using System;

// Token: 0x020000C5 RID: 197
public class T
{
	// Token: 0x0600098E RID: 2446 RVA: 0x0009B624 File Offset: 0x00099824
	public T()
	{
		T.thanhcong = "Cường hóa thành công";
		T.thatbai = "Cường hóa thất bại";
		T.tathieuung = "Tắt hiệu ứng";
		T.bathieuung = "Bật hiệu ứng";
		T.khac = "Khác";
		T.members = "Thành viên: ";
		T.thoigianconlai = "Thời gian còn lại ";
		T.hiennguoichoi = "Hiện người chơi";
		T.hoihienguoichoi = "Bạn có muốn hiện những người chơi khác";
		T.hoiannguoichoi = "Bạn có muốn ẩn những người chơi khác";
		T.annguoichoi = "Ẩn người chơi";
		T.trangbi1 = "T.Bị 1";
		T.trangbi2 = "T.Bị 2";
		T.quaylai = "Quay Lại";
		T.hoprac = "Tạo";
		T.bonguyenlieu = "Nhà ngươi hãy bỏ nguyên liệu vào, ta sẽ ghép cho";
		T.can_not_move = "Bạn không thiể di chuyển khi đang bán hàng, Bạn có muốn nghỉ bán không";
		T.nhapSlogan = "Nhập tên cửa hàng";
		T.hoanthanh = "Hoàn Thành";
		T.nhapsai = "Nhập sai vui lòng nhập lại";
		T.hoidaugia = "Bạn có muốn bán: ";
		T.nhapgiaban = "Nhập giá bán";
		T.daugia = "Bán";
		T.gianHang = "Gian Hàng";
		T.NghiBan = "Nghỉ Bán";
		T.numberHotLine = string.Empty;
		T.HotLine = string.Empty;
		T.TimeThachDau = "Thách đấu bắt đầu sau: ";
		T.chuaboduclo = "Hãy bỏ bùa huyền bí và vật phẩm của nhà ngươi vào rồi ta sẽ đục lỗ cho.";
		T.DucLo = "Đục lỗ";
		T.muaNhieu = "Mua Nhiều";
		T.bongoc = "Nhà ngươi hãy bỏ ngọc vào, ta sẽ ghép ngọc cho";
		T.hopngoc = "Hợp ngọc";
		T.hetNgoc = "Nhà ngươi đã hết ngọc loại này rồi, hãy ra ngoài đánh quái để thu thập rồi mang về đây cho ta";
		T.khongbothem = "Không thể bỏ thêm";
		T.chuaboitem = "Nhà ngươi hãy bỏ vũ khí và ngọc vào ta sẽ khảm cho.";
		T.bovao = "Bỏ vào";
		T.khamNgoc = "Khảm Ngọc";
		T.khongcongua = "Bạn không thú cưỡi trong hành trang.";
		T.Logifail = "Kết nối thất bại, vui lòng kiểm tra lại đường truyền.";
		T.Tips = "Tips: ";
		T.mapName = new string[]
		{
			"Ngôi Làng Nhỏ",
			"Làng Sói Trắng",
			"Khu mỏ",
			"Bìa Rừng",
			"Hang Lửa",
			"Rừng Ảo Giác",
			"Khe Vực",
			"Cánh Đồng Sói",
			"Thung Lũng Kỳ Bí",
			"Hồ Ký Ức",
			"Bãi Đất Trống",
			"Bờ Biển",
			"Vực Đá",
			"Rặng Đá Ngầm",
			"Nghĩa Địa Tàu Đắm",
			"Đầm Lầy",
			"Đền Cổ",
			"Hang Dơi",
			"Hang Sói Quỷ",
			"Cửa Biển",
			"Sa Mạc",
			"Đồi Cát",
			"Vực Lún",
			"Hố Tử Thần",
			"Nghĩa địa cát",
			"Rừng Chết",
			"Suối Ma",
			"Thung Lũng Đá",
			"Boss Guardian",
			"Hầm Mộ Tầng 1",
			"Hầm Mộ Tầng 2",
			"Hầm Mộ Tầng 3",
			"Hầm mộ quái vật",
			"Thành Phố Kho Báu",
			"Khu phía Tây",
			"Khu phía Đông",
			"Đấu Trường",
			"Rừng cao nguyên",
			"Con đường hiểm trở",
			"Vách đá cheo leo",
			"Núi Cầu Vòng",
			"Lối lên Thượng giới",
			"Đèo hoang sơ",
			"Đường xuống lòng đất",
			"Cây cầu ma ám",
			"Cổng vào Hạ giới",
			"Đấu Trường",
			"Đồi xác chết",
			"Ngã tư tử thần",
			"Phó bản mới",
			"Khu vườn",
			"Cổng thiên đàng",
			"Cổng địa ngục",
			"Chuẩn bị",
			"Làng ánh sáng",
			"Chuẩn bị",
			"Làng gió",
			"Chuẩn bị",
			"Làng sét",
			"Chuẩn bị",
			"Làng lửa",
			"Chiến trường",
			"Địa ngục tầng 1",
			"Rừng medusa",
			"Rừng Chimera",
			"Rừng quái vật",
			"Thác reo",
			"Thành phố cảng",
			"Khu bờ nam",
			"Khu bờ bắc",
			"Khu bờ tây",
			"Rừng chuột",
			"Rừng hoa đỏ",
			"Vịnh Caribe",
			"Mê cung",
			"Mê cung tầng 1",
			"Mê cung tầng 2",
			"Mê cung tầng 3",
			"Mê cung tầng 4",
			"Mê cung tầng cuối",
			"Thi đấu",
			string.Empty,
			"Khu mua bán",
			"Cửa đông",
			"Cửa tây",
			"Cửa nam",
			"Cửa bắc",
			"Đấu trường",
			"Map 88",
			"Map 89",
			"Map 90",
			"Map 91"
		};
		T.mTips = new string[]
		{
			"Nhấn giữ nút chat 2s sẽ bật khung chat nhanh.",
			"Thùng may mắn xuất hiện mỗi giờ ngẫu nhiên các bản đồ.",
			"Một bang hội có thể chiếm nhiều mỏ tài nguyên.",
			"Săn quái và thách đấu sẽ tăng điểm danh vọng.",
			"Điểm danh vọng tụt giảm nếu hiệp sĩ không hoạt động trong một thời gian.",
			"Hoàn thành phó bản có thể kiếm được trứng thú nuôi.",
			"Ghi danh chiến trường với Mr. Ballard ở Hang Lửa.",
			"Boss sẽ tái sinh sau 12 tiếng tính từ lúc bị đánh chết.",
			"Cường hóa vật phẩm sẽ ngẫu nhiên được Khúc Xương.",
			"Con Ma sẽ xuất hiện sau khi hiệp sĩ đạt level 20.",
			"Sức khỏe có thể phục hồi khi đứng yên hoặc dùng thức ăn.",
			"Đồng Tyche hiệp sĩ sẽ có thể vào khu hai giờ miễn phí.",
			"Trong khu 2 giờ tỉ lệ rớt đồ và kinh nghiệm sẽ cao hơn các khu khác."
		};
		T.mQuickChat = new string[]
		{
			"Chào!",
			"muahahaha!!!",
			"Đợi một chút!",
			"Gà quá!",
			"Pro quá!",
			"Lag quá!",
			"Party không?",
			"Anh em tập trung",
			"Đi nào anh em!",
			"Chiếm mỏ thôi mọi người",
			"Săn boss mọi người ơi!",
			"Đứa nào dám đồ sát ta!",
			"Đông quá vậy",
			"PK không thằng kia?",
			"Ai cho vào bang với!",
			"Bang tuyển thành viên chăn onl!",
			"Đi ngủ đi",
			"Bye!",
			"Nguy hiểm chạy lẹ!!!",
			"Cứu tôi với HELP!!"
		};
		T.TchangSv = "Bạn vừa chuyển qua Server Việt Nam, vui lòng sử dụng tài khoản khác để đăng nhập";
		T.TuseNgua = "Thú cưỡi";
		T.TisNguaNau = "Xuống ngựa để tấn công!";
		T.speedUp = "Tăng tốc";
		T.textXuongNgua = "Xuống Ngựa";
		T.textHoiXuongNgua = "Ngựa sẽ bị mất khi xuống ngựa, Bạn có muốn xuống ngựa không ?";
		T.infoArena = "Thông tin chiến trường:";
		T.backBattlefield = "Tham gia chiến trường sau: ";
		T.yes = "Đồng ý";
		T.no = "Không";
		T.choimoi = "Chơi Mới";
		T.choi_daco_TK = "Chơi Tiếp";
		T.daco_TK = "Có Tài Khoản";
		T.doi_TK_khac = "Đổi Tài Khoản";
		T.minutes = "phút";
		T.changeScrennSmall = "Màn hình nhỏ";
		T.normalScreen = "Màn hình lớn";
		T.changeSizeScreen = "Bạn có muốn thoát game để thay đổi màn hình không ? ";
		T.del = "Xóa";
		T.username = "Tài khoản";
		T.password = "Mật khẩu";
		T.login = "Đăng nhập";
		T.menu = "Menu";
		T.select = "Chọn";
		T.close = "Đóng";
		T.waitLogin = "Đang đăng nhập vui lòng chờ.";
		T.nulluserpass = "Vui lòng nhập tên và mật khẩu.";
		T.next = "Tiếp";
		T.server = "Server";
		T.create = "Tạo";
		T.level = "Cấp: ";
		T.Lv = "Lv";
		T.namePlayer = "Tên nhân vật";
		T.nameMin6char = "Tên nhân vật phải dài hơn 5 ký tự.";
		T.back = "Trở về";
		T.remember = "Nhớ mật khẩu";
		T.hotKey = "Phím tắt";
		T.congdiem = "Cộng điểm";
		T.phim = "Phím ";
		T.giaotiep = "Giao tiếp";
		T.createChar = "Tạo mới";
		T.buy = "Mua";
		T.diemtiemnang = "Điểm tiềm năng: ";
		T.diemkynang = "Điểm kỹ năng: ";
		T.nhanvat = "Nhân vật: ";
		T.mainQuest = "Nhiệm vụ chính:";
		T.subQuest = "Nhiệm vụ phụ:";
		T.viewMap = "Bản đồ";
		T.nhan = "Nhận";
		T.tra = "Hoàn thành";
		T.cancel = "Hủy";
		T.quest = "Nhiệm vụ";
		T.chat = "Chat";
		T.noMessage = "Bạn không có tin nhắn";
		T.delTabChat = "Đóng tab này";
		T.read = "Đọc";
		T.view = "Xem";
		T.change = "Thay đổi";
		T.equip = "Trang bị";
		T.setPoint = "Cộng điểm";
		T.cong = "Cộng";
		T.danglaydulieu = "Đang lấy dữ liệu";
		T.hoihuyQuest = "Bạn có muốn hủy nhiệm vụ ";
		T.hoiBuy = "Bạn muốn mua ";
		T.pleaseWait = "Vui lòng chờ.";
		T.leftRing = "Nhẫn trái";
		T.rightRing = "Nhẫn phải";
		T.hoiDelItem = "Bạn muốn bỏ ";
		T.nhapsoluongcanmua = "Nhập số lượng cần mua:";
		T.khongcovatphanphuhop = "hành trang không có vật phẩm phù hợp.";
		T.cong1diem = "Bạn muốn công 1 điểm vào ";
		T.nhapsodiem = "Nhập vào số điểm bạn muốn cộng vào ";
		T.nhohonhoacbang = " (nhỏ hơn hoặc bằng ";
		T.cong1kynang = "Bạn muốn công 1 diểm vào kỹ năng ";
		T.setKey = "Gán phím";
		T.nhatdcvatpham = "Nhặt được vật phẩm";
		T.farfocus = "Mục tiêu ở quá xa";
		T.party = "Đội nhóm";
		T.noParty = "Bạn không có nhóm.";
		T.invite = "Mời thêm";
		T.mainLeave = "Yêu cầu rời đội";
		T.leave = "rời đội";
		T.mainCancle = "Giải tán đội";
		T.addFriend = "Kết bạn";
		T.nullParty = "Không có đội ở gần";
		T.gianhap = "Gia nhập";
		T.lapnhom = "Tạo nhóm";
		T.khacclass = "Bạn không thể dùng đồ của trường phái khác.";
		T.listParty = "Danh sách nhóm";
		T.hoithachdau = " gởi cho bạn một lời mời thách đấu. Mức cược là ";
		T.khoa = "Khóa";
		T.fullBuySell = "Mỗi lần giao dịch tối đa 9 vật phẩm.";
		T.kynangchuass = "Kỹ năng chưa sẵn sàng";
		T.price = "Giá";
		T.deleteFriend = "Bạn muốn xóa người này ra khỏi danh sách?";
		T.beginChat = "Trò chuyện với ";
		T.listFriend = "Danh Sách Bạn Bè";
		T.nullFriend = "Làm quen nhiều người hơn nào.";
		T.hoivaonhom = "Bạn muốn vào đội ";
		T.hoilapnhom = "Bạn muốn lập 1 đội?";
		T.item = "Vật phẩm";
		T.dungitem = "Bạn muốn dùng vật phẩm này?";
		T.use = "Sử dụng";
		T.underlevel = "Cấp độ chưa đủ.";
		T.chuahoc = "Chưa học kỹ năng này.";
		T.yeucau = "Yêu cầu ";
		T.nangluong = "Hao tốn MP: ";
		T.delay = "thời gian hồi: ";
		T.timebuff = "thời gian hổ trợ: ";
		T.hieuung = "hiệu ứng: ";
		T.timehieuung = "thời gian h.ứng: ";
		T.tanghpdung = "tăng HP nạp: ";
		T.tangmpdung = "tăng MP nạp: ";
		T.phamvi = "Phạm vi: ";
		T.phamvilan = "Phạm vi lan: ";
		T.somuctieu = "Số mục tiêu: ";
		T.banthan = "bản thân";
		T.moinguoi = "mọi người";
		T.trongdoi = "đội";
		T.kethu = "đối thủ";
		T.buff = "Bổ trợ";
		T.active = "Tấn công";
		T.passive = "Bị động";
		T.kynang = "Kỹ năng ";
		T.velang = "Về làng";
		T.muonvelang = "Bạn có muốn về làng hồi máu?";
		T.sell = "Bán";
		T.hoisell = "Bạn muốn bán ";
		T.LVyeucau = "Lv yêu cầu: ";
		T.yeucauketban = " muốn kết bạn. Bạn có đồng ý không?";
		T.chapnhan = "Chấp nhận";
		T.tuchoi = "Từ chối";
		T.myseft = "Hành Trang - Nhân vật";
		T.info = "Thông tin";
		T.trochuyen = "Trò chuyện";
		T.moiParty = "Mời vào nhóm";
		T.vucbo = "Vứt bỏ";
		T.coin = "vàng";
		T.gem = "ngọc";
		T.hoithoat = "Bạn muốn thoát khỏi trò chơi";
		T.exit = "Thoát";
		T.dangdangnhap = "Đang kết nối đến máy chủ. Vui lòng chờ.";
		T.hoiFrist = "Bạn đã từng chơi và có tài khoản Hiệp Sĩ Online từ trước?";
		T.oldPlayer = "Đã có";
		T.newPlayer = "Chưa có";
		T.register = "Đăng ký";
		T.help = "Hỗ trợ";
		T.clearData = "Xóa dữ liệu";
		T.lienhe = "Bạn có muốn lấy lại (hoặc đổi) mật khẩu?";
		T.dacotaikhoan = "Đã có tài khoản";
		T.dagoidangky = "Đã gởi thông tin đăng ký. Vui lòng chờ xác nhận.";
		T.quenpass = "Quên m.khẩu";
		T.thulai = "Quá trình xử lý quá lâu.Bạn vui lòng thử lại.";
		T.texthelpRegister = string.Empty;
		T.lostMana = "Không đủ năng lượng.";
		T.capdochuadu = "Cấp độ bạn chưa đủ";
		T.nhandc = ". Bạn sẽ nhận được:";
		T.diemcongvao = " điểm cộng vào ";
		T.hoisinh = "Hồi sinh";
		T.newParty = "Tạo đội mới";
		T.oso = "ô số ";
		T.loimoiParty = " muốn mời bạn vào nhóm. Bạn có đồng ý không?";
		T.moikhoinhom = "Bạn đã bị mời khỏi nhóm.";
		T.giaitannhom = "Nhóm bạn đã bị giải tán.";
		T.roikhoinhom = "Bạn đã rời khỏi nhóm.";
		T.vuataonhom = "Nhóm của bạn vừa được tạo thành công.";
		T.disconnect = "Bạn bị mất kết nối với máy chủ.";
		T.hoigiaodich = " muốn mời bạn giao dịch. Bạn có đồng ý không?";
		T.buySell = "Giao dịch";
		T.huygiaodich = "Giao dịch của bạn đã bị hủy.";
		T.khongthegiaodich = "Bạn không thể giao dịch vật phẩm nhiệm vụ";
		T.chuyentien = "Chuyển tiền";
		T.nhapsotien = "Nhập vào số tiền bạn muốn giao dịch (nhỏ hơn bằng 10 triệu).";
		T.xacnhan = "Xác nhận";
		T.giaodichthanhcong = "Giao dịch đã hoàn tất.";
		T.giatrinhapsai = "Giá trị nhập nhiều hơn số tiền bạn đang có.";
		T.banmuongiaodich = "Bạn đã kiểm tra kỹ và muốn giao dịch?";
		T.xincho = "Xin chờ";
		T.setPk = "Đeo cờ";
		T.dosat = "đồ sát";
		T.on = "Bật";
		T.off = "Tắt";
		T.hut = "né đòn";
		T.voigia = "Với giá ";
		T.la = "là";
		T.tinden = "Tin đến";
		T.khongthecong = "Số điểm cộng tối đa của bạn là ";
		T.changeArea = "Chuyển khu vực";
		T.Area = "Khu ";
		T.nhapsdt = "Nhập số điện thoại, email";
		T.trora = "Đóng trò chuyện";
		T.tinnhan = "Tin nhắn";
		T.friend = "Bạn bè";
		T.logout = "Đăng xuất";
		T.autoHP = " Tự bơm máu";
		T.auto = "Tự động";
		T.autoFire = " Tự động đánh";
		T.timduongtoilang = "phải mau tìm tới làng sói trắng theo lời mẹ thôi.";
		T.again = "Thử lại";
		T.nhanNv = "Nhận NV ";
		T.traNv = "Trả NV ";
		T.tacdunglen = "Tác dụng lên";
		T.mucdohoanthanh = "Mức độ hoàn thành ";
		T.khongthetraodoi = "Không thể trao đổi vật phẩm này";
		T.xinchogiaodich = "xin chờ ";
		T.xacnhangiaodich = " xác nhận giao dịch";
		T.chuyensang = "Chuyển sang ";
		T.keypad = "keypad";
		T.touch = "touch";
		T.Ring = "Nhẫn";
		T.menuChinh = "MENU";
		T.chucnang = "Chức năng";
		T.khuvuc = "Khu vực";
		T.chimang = "Chí mạng: ";
		T.tatcasatthuong = "Tất cả sát thương: ";
		T.satthuongvatly = "Sát thương vật lý: ";
		T.satthuonglua = "Sát thương lửa: ";
		T.satthuongdoc = "Sát thương độc: ";
		T.satthuongdien = "Sát thương điện: ";
		T.nedon = "Né đòn: ";
		T.phongthu = "Phòng thủ: ";
		T.hoihelp = "Bạn có muốn thực hiện phần hướng dẫn người chơi mới. Vui lòng chọn Tiếp nếu muốn, Hủy nếu không. Bạn cũng có thể tắt hướng dẫn bằng cách vào menu - chức năng - tắt hướng dẫn";
		T.endHelp = "Tắt hướng dẫn";
		T.dangketnoilai = "Đang kết nối lại. Vui lòng chờ.";
		T.vetruoc = "Về trang ";
		T.toitruoc = "Tới trang ";
		T.listnull = "Không có ai trong danh sách";
		T.suckhoe = "Sk: ";
		T.yeusuckhoe = "Không đủ sức khỏe";
		T.tabhanhtrang = "Hành Trang";
		T.tabtrangbi = "Trang Bị";
		T.tabthongtin = "Nhân Vật";
		T.tabkynang = "Kỹ Năng";
		T.tabnhiemvu = "Nhiệm Vụ";
		T.tabhethong = "Thiết Lập";
		T.tabchucnang = "Chức Năng";
		T.strhelp = "-Phím bấm\n  + Dùng các phím điều hướng hoặc 2,4,6,8 để di chuyển.\n  + Phím 5 (hoặc phím giữa),1,3,7,9 để sử dụng các tuyệt chiêu và bơm máu, năng lượng.\n  + Phím * để bật khung chat, phím 0 để chuyển tab dùng tuyệt chiêu.\n-NPC\n  +Lisa và Emma: Bán máu, năng lượng và phục hồi thể lực.\n  +Doubar và Alisama: Bán các trang bị như áo, quần, gang tay ...\n  +Aman và Amin: rương đồ của bạn sẽ rất an toàn khi có họ.\n  +Hammer và Black eye: Bán vũ khí.\n  +Đá dịch chuyển: giúp bạn đi lại giữa các khu vực với nhau.\n  +Zulu: thầy phù thủy giúp bạn thay đổi kiểu tóc và cũng là người giao các nhiệm vụ hằng ngày.\n  +Pháp sư: là người bán nguyên liệu cũng như giúp bạn cường hóa trang bị.\n  +Zoro và Benjamin: sẽ giúp bạn tạo Bang hội, và các vật phẩm Bang cũng được bán từ họ.\n  +Phó thống lĩnh: là người đưa bạn đến các Phó bảng.\n  +Tiên cánh: sẽ giúp bạn có được những đôi cánh sức mạnh và cũng rất đẹp đấy.";
		T.noichuyen = "Nói chuyện";
		T.download = "Tải";
		T.dcchimang = "chí mạng";
		T.dcxuyengiap = "xuyên giáp";
		T.mau = "Máu: ";
		T.khangtatcast = "Kháng tất cả sát thương: ";
		T.xuyengiap = "Xuyên giáp: ";
		T.nangluong = "Năng lượng: ";
		T.satthuongbang = "Sát thương băng: ";
		T.phansatthuong = "Phản sát thương: ";
		T.giet = "Diệt ";
		T.nhat = "Nhặt ";
		T.autoItem = " Tự nhặt đồ";
		T.fullInven = "Hành trang đầy";
		T.helpCapchar = "Hãy bấm đúng các ký tự gợi ý để tiêu diệt con ma!";
		T.cauhinhthap = " cấu hình thấp";
		T.naptien = "Nạp";
		T.dangdungtocnay = "Bạn đang sử dụng bộ tóc này.";
		T.dasohuu = "Đã sở hữu";
		T.chapnhanketban = " đã chấp nhận lời mời kết bạn.";
		T.hang = "Hạng";
		T.chuanhapsdt = "Bạn chưa nhập email hoặc số di động.";
		T.chuanhapmk = "Bạn chưa nhập mật khẩu";
		T.sdtkhople = "Số di động không hợp lệ. Xin nhập theo mẫu 0912345678 hoặc 84918765432";
		T.emailkhople = "Email không hợp lệ. Xin nhập theo mẫu tencuaban@yahoo.com hoặc tencuaban@gmail.com";
		T.kiemtralai = "Xin kiểm tra chính xác để có thể lấy lại được tài khoản trong trường hợp quên mật khẩu.";
		T.sdt = "Số di động: ";
		T.email = "Địa chỉ mail: ";
		T.nangcapyeucau = "Nâng cấp cần: Lv ";
		T.thongbaotuserver = "Thông báo từ server";
		T.khongganmauvaophimnay = "Vật phầm không thể gán vào phím này.";
		T.questitem = "Vật phẩm nhiệm vụ";
		T.layra = "Lấy ra";
		T.catvao = "Cất vào";
		T.nhapsoluongcanlay = "Nhập số lượng cần lấy ra:";
		T.nhapsoluongcancat = "Nhập số lượng cần cất vào:";
		T.sellmore = "Bán nhiều";
		T.banhetxanh = "Bán hết đồ xanh +0";
		T.banhettrang = "Bán hết đồ trắng +0";
		T.khongconxanh = "Không còn món đồ xanh nào trong hành trang.";
		T.khongcontrang = "Không còn món đồ trắng nào trong hành trang.";
		T.dotrang = " đồ trắng.";
		T.doxanh = " đồ xanh.";
		T.chiphi = "Chi phí:";
		T.nguyenlieu = "Nguyên liệu:";
		T.tilemayman = "Tỉ lệ may mắn:";
		T.hoac = " hoặc ";
		T.dapdo = "Cường hóa";
		T.hoidapxuluong = "Mi muốn cường hóa trang bị bằng ";
		T.hay = " hay ";
		T.setting = "Cài đặt";
		T.bovatphamvao = "Hãy bỏ trang bị muốn cường hóa vào, ta sẽ giúp mi.";
		T.dapbangxu = "Mi muốn cường hóa trang bị này với ";
		T.chest = "Rương đồ";
		T.namenaptien = "Nạp tiền";
		T.trochuyenvoi = "Trò chuyện với ";
		T.noEvent = "Danh sách rỗng";
		T.mevent = "Sự kiện";
		T.loimoikb = "Yêu cầu kết bạn.";
		T.moivaoParty = "Mời bạn vào nhóm.";
		T.loimoigiaodich = "Mời bạn giao dịch.";
		T.thachdau = "Thách đấu";
		T.loimoithachdau = "Lời mời thách đấu.";
		T.autoBuff = "Tự động Buff";
		T.thongbao = "Thông báo";
		T.hoichoniconclan = "Bạn muốn chọn biểu tượng này cho clan của mình?";
		T.iconclan = "Biểu tượng Clan";
		T.contentclan = "Biểu tượng đặc trưng cho bang hội.";
		T.showAuto = " hiện thông tin";
		T.addmemclan = "Mời vào Bang";
		T.moivaoclan = " muốn mời bạn gia nhập Bang.";
		T.loimoivaoclan = "Lời mời vào Bang.";
		T.clan = "Bang hội";
		T.bieutuong = "Biểu tượng: ";
		T.chuakhauhieu = "chưa có khẩu hiệu.";
		T.xinvaoclan = "Xin vào Hội";
		T.xemdanhsach = "Danh sách thành viên";
		T.gop = "Góp ";
		T.nhapsoxumuongop = "Nhập số vàng bạn muốn góp vào Bang hội.";
		T.nhapsoluongmuongop = "Nhập số ngọc bạn muốn góp vào Bang hội.";
		T.doiSlogan = "Thay đổi khẩu hiệu";
		T.doiNoiquy = "Thay đổi nội quy";
		T.phonghacap = "Phong/Hạ cấp";
		T.nhapthongtindoi = "Vui lòng nhập thông tin bạn muốn thay đổi.";
		T.slogan = "Khẩu hiệu";
		T.noiquy = "Nội quy";
		T.thanhvien = "Thành viên";
		T.chucvu = "Chức vụ: ";
		T.moiroiclan = "Yêu cầu rời Bang";
		T.roiclan = "Rời Bang";
		T.tabThuLinh = "Thủ lĩnh";
		T.tabBangHoi = "Bang Hội";
		T.chattoanbang = "Chat Bang";
		T.doithongbao = "Thay đổi thông báo";
		T.bankhongconclan = "Bạn không còn trong Bang.";
		T.soluong = "Số lượng: ";
		T.donggopclan = "Đóng góp Bang";
		T.quyxu = "Quỹ xu: ";
		T.quyngoc = "Quỹ ngọc: ";
		T.hoibatdosat = "Bạn muốn bật chế độ đồ sát?";
		T.update = "Cập nhật";
		T.minimap = "Bản đồ nhỏ";
		T.textkenhthegioi = "Chat kênh Thế giới";
		T.text2kenhthegioi = "Kênh TG - ";
		T.kenhthegioi = "Bạn có muốn chat kênh thế giới ";
		T.noidungnhusau = " với nội dung như sau:";
		T.nhapnoidung = "Nhập nội dung";
		T.chatParty = "Chat đội nhóm";
		T.phi = "Phí";
		T.replace = "Chuyển hóa";
		T.hoichuyendo = "Mi có muốn chuyển cấp cường hóa từ ";
		T.qua = " qua ";
		T.dochuyen = "Đồ chuyển: ";
		T.donhan = "Đồ nhận: ";
		T.plusnhanduoc = "Kết quả chuyển hóa:";
		T.boitemreplace = "Hãy bỏ 2 vật phẩm muốn hoán đổi cường hóa vào. Phần còn lại cứ để ta.";
		T.nhanban = "nhân bản";
		T.khongconhiemvu = "Không có nhiệm vụ";
		T.timeyeucau = "Thời gian ncấp: ";
		T.taoCanh = "Tạo cánh";
		T.hoiTaoCanh = "Hiệp sĩ có muốn tạo ";
		T.Lvsudung = "cấp độ yêu cầu ";
		T.nangcap = "nâng cấp";
		T.sudungsau = "Sử dụng sau ";
		T.phandon = "Phản đòn";
		T.hoiroiClan = "Bạn muốn rời khỏi Bang hội?";
		T.updateData = "Đang cập nhật dữ liệu, vui lòng chờ!";
		T.updateok = "Dữ liệu mới đã được cập nhật.";
		T.hoinangcapcanh = "Hiệp sĩ có muốn nâng cấp ";
		T.mVolume = new string[]
		{
			"Nhạc nền: ",
			"Hiệu ứng: "
		};
		T.listserver = "Chọn Máy Chủ";
		T.SetMusic = "Âm thanh";
		T.maychu = "Máy chủ ";
		T.tuoi = "Tuổi: ";
		T.tancong = "Tấn công: ";
		T.choan = "Cho ăn";
		T.lockMap = "Chức năng bản đồ đang tạm khóa.";
		T.delMess = "Xóa sự kiện";
		T.khongthedung = "Không thể sử dụng.";
		T.about = "Giới thiệu";
		T.textabout1 = "Knight Age Online\nVersion: ";
		T.textabout2 = "Silver Bat Studio (VN)\nSound by www.freesound.org\nMusic by audionautix.com\nFor Help: knight.online.ssvn@gmail.com";
		T.nokiaprivacy = "Điều khoản";
		T.thoigianaptrung = "Thời gian nở ";
		T.aptrung = "Ấp Trứng";
		T.nhaptaikhoan = "Nhập tài khoản (nếu có)";
		T.choi = "Chơi";
		T.moly = "Mở ly";
		T.startdraw = "Bắt đầu";
		T.choitiep = "Chơi tiếp";
		T.chonlai = "Chọn lại";
		T.hopNguyenLieu = "Hãy đặt vào 5 nguyên liệu cùng loại, cấp muốn hợp, ta sẽ giúp cho. ";
		T.hopThanh = "Hợp thành";
		T.YOUNEED = "Bạn cần phải có";
		T.mhang = new string[]
		{
			"Nhất",
			"Nhì",
			"Ba",
			"Tư"
		};
		T.mChucVuClan = new string[]
		{
			"Thủ Lĩnh",
			"Phó Chỉ Huy",
			"Đại Hiệp Sĩ",
			"Hiệp Sĩ Cao Quý",
			"Hiệp Sĩ Danh Dự",
			"Thành Viên Mới",
			"Đã rời khỏi Bang"
		};
		T.mChucVuClan = new string[]
		{
			"Thủ Lĩnh",
			"Phó Chỉ Huy",
			"Đại Hiệp Sĩ",
			"Hiệp Sĩ Cao Quý",
			"Hiệp Sĩ Danh Dự",
			"Thành Viên Mới",
			"Đã rời khỏi Bang"
		};
		T.story = new string[]
		{
			"Hơn 500 năm trước khi chiến tranh giữa hai vương quốc Thượng giới và Hạ giới nổ ra, dân chúng không có được một ngày bình yên. Họ luôn phải sống trong tâm trạng lo lắng không chỉ bởi cuộc chiến mà còn những câu chuyện về sự xuất hiện của rất nhiều quái vật sống dậy từ cõi chết.",
			"Chính vì thế những Hiệp Sĩ của tự do xuất hiện với sứ mệnh làm thay đổi cả thế giới, thời đại của những Hiệp Sĩ bắt đầu."
		};
		T.mKynangPet = new string[]
		{
			"Nhóm SM",
			"Nhóm KL",
			"Nhóm TL",
			"Nhóm TT"
		};
		T.textCreateChar = new string[]
		{
			"Trường phái",
			"Tóc",
			"Mắt",
			"Đầu"
		};
		T.mClass = new string[]
		{
			"Chiến Binh",
			"Sát thủ",
			"Pháp Sư",
			"Xạ Thủ"
		};
		T.mCreateChar_HAIR = new string[][]
		{
			new string[]
			{
				"Rơm",
				"Bụi"
			},
			new string[]
			{
				"Dài",
				"Ngắn"
			}
		};
		T.mCreateChar_EYE_FACE = new string[][]
		{
			new string[]
			{
				"Đen",
				"Xanh",
				"Đen",
				"Xanh"
			},
			new string[]
			{
				"Tròn",
				"Yêu tinh"
			}
		};
		T.mKyNang = new string[]
		{
			"Sức Mạnh",
			"Khéo Léo",
			"Thể Lực",
			"Tinh Thần"
		};
		T.mColorPk = new string[]
		{
			"Tháo cờ",
			"Đỏ",
			"Xanh lá",
			"Xanh dương",
			"Tím",
			"Vàng",
			"Cam",
			"Hồng",
			"Xanh da trời",
			"Đen"
		};
		T.mAuto = new string[]
		{
			"Sử dụng HP khi còn dưới ",
			"Sử dụng MP khi còn dưới"
		};
		T.mUtien = new string[]
		{
			"Ưu tiên: < nhỏ đến lớn >",
			"Ưu tiên: < lớn đến nhỏ >"
		};
		T.mAutoItem = new string[]
		{
			"Vật phẩm: ",
			"MP,HP: ",
			"Vàng: "
		};
		T.mValueAutoItem = new string[][]
		{
			new string[]
			{
				"nhặt tất cả",
				"nhặt từ đồ xanh",
				"nhặt từ đồ vàng",
				"nhặt từ đồ tím",
				"nhặt từ đồ cam",
				"không nhặt"
			},
			new string[]
			{
				"nhặt tất cả",
				"chỉ nhặt HP",
				"chỉ nhặt MP",
				"không nhặt"
			},
			new string[]
			{
				"nhặt",
				"không nhặt"
			}
		};
		T.helpMenu = new string[]
		{
			"chọn vào đây"
		};
		T.mQuest = new string[]
		{
			"đang làm",
			"đã xong"
		};
		T.mHelp = new string[][]
		{
			new string[]
			{
				"Chào mừng bạn đến với thế giới của các hiệp sĩ",
				"Sau đây là phần hướng dẫn người chơi mới",
				"Dùng phím lên, xuống, trái phải để di chuyển nhân vật.",
				"Bạn cũng có thể sử dụng các phím điều hướng để di chuyển theo ý mình",
				"Giờ bạn hãy di chuyển đến vị trí màu vàng trên màn hình"
			},
			new string[]
			{
				"Rất tốt,tiếp theo bạn hãy dùng phím 5 hoặc phím chọn để đánh 1 con quái.",
				"Dấu mũi tên phía trên chính là dấu hiệu nhận biết bạn đang nhắm tới con quái đó",
				string.Empty,
				"Giết 1 con quái cũng dễ thôi đúng không nào. Khi đánh vào những con quái bạn sẽ nhận được một lượng điểm kinh nghiệm.",
				"Ngoài ra còn có thể nhặt được vật phẩm nữa. Giờ hãy thử đánh vài con quái để kiểm chứng nhé.",
				string.Empty,
				"Vật phẩm bạn nhặt được sẽ cất vào trong hành trang",
				"Hãy vào hành trang xem ta có gì trong đấy nào",
				"Để vào đó bạn hãy nhấn phím chọn trái, chọn mục Hành trang -  Nhân vật.",
				"Nhấn chọn trái để vào hành trang."
			},
			new string[]
			{
				"Đây là hành trang nơi cất giữ mọi thứ cho bạn",
				"Hiện thời bạn đang có một vài bình máu, năng lượng và cả 1 đôi giày.",
				"Hãy thử sử dụng bình máu bằng cách di chuyển khung chọn màu trắng đến bình máu",
				"Bấm phím chọn trái và chọn mục sử dụng",
				"Nhấn phím chọn và chọn sử dụng",
				"Rất tốt, ngoài ra bạn còn có thể dùng các bình máu và năng lượng bằng một cách nữa",
				"Đó là gắn chúng vào phím tắt để có thể thao tác nhanh",
				"Hãy lại di chuyển khung chọn tới bình máu 1 lần nữa và nhấn chọn.",
				"Lần này thì hãy chọn gán phím và chọn 1 phím mà bạn thấy là thuận tay nhất nha.",
				"Nhấn phím chọn và chọn mục gán phím",
				"Nhấn phím chọn và chọn mục gán phím",
				"Việc sử dụng năng lượng cũng tương tự như thế.",
				"Bạn hãy thử dùng và gắn phím khi cần thiết nha."
			},
			new string[]
			{
				"Trong hành trang của bạn còn có thêm 1 đôi giày",
				"Ngoài tác dụng làm đẹp thì đôi giày này còn giúp bạn mạnh mẽ hơn đấy",
				"Việc mang nó cũng tương tự như là sử dụng máu",
				"Giờ bạn thử đeo nó vào nha",
				"Nhấn phím chọn rồi chọn mục sử dụng",
				"Cũng đơn giản thôi phải không nào.",
				"Bất cứ vật phẩm nào bạn mặc trên người sẽ xuất hiện trong Trang bị",
				"Và đây chính là Trang bị của bạn hãy chọn vào để xem ta có gì nào ",
				"Di chuyển khung chọn tới đây"
			},
			new string[]
			{
				"Đây chính là phần Trang bị giúp cho bạn biết được mình đang có những gì trên người",
				"Phần bên trái hiển thị nhân vật và thông tin sức khỏe,điểm pk của bạn",
				"Bên phải là thông tin về sát thương, phòng thủ và % kháng bạn đang có",
				"Còn dưới này là chính là các vật phẩm bạn đang có trên người",
				"Khi bạn có một món đồ trong Hành trang và muốn mặc vào người",
				"Bạn cũng có thể vào đây chọn đúng vị trí tương ứng và chọn thay đổi",
				"Ngoài ra nó còn giúp bạn so sánh khi có nhiều món đồ cùng loại nữa",
				"Hãy thử chức năng này khi bạn nhặt dc 1 vài món đồ nào đó",
				"Giờ hãy trở ra để tiếp tục cuộc phiêu lưu thôi",
				"Nhấn phím chọn phải để thoát ra"
			},
			new string[]
			{
				string.Empty,
				"Đây là bản đồ nhỏ giúp bạn có 1 góc nhìn lớn hơn về khu vực đang đứng",
				"Hãy chú ý đến điểm chớp màu vàng trên bản đồ đó chính là nơi bạn cần đến",
				"Phần thông tin về máu, năng lượng, cấp độ của bạn là đây.",
				"Khi bạn chọn đến 1 mục tiêu nào đó thì thông tin mục tiêu sẻ hiện ở đây.",
				"Nếu muốn thay đổi mục tiêu bạn chỉ cần nhấn phím chọn phải.",
				"Bạn có đến 2 thanh kỹ năng hãy dúng phím 0 thay đổi",
				"Phím * dùng để chat và phím # sẽ giúp bạn mở phần sự kiện của mình."
			},
			new string[]
			{
				"Bạn vừa lên được 1 cấp, và sẽ có rất nhiều điều hay ho khi lên cấp mà bạn cần phải biết",
				"Giờ thì hãy vào Hành Trang - Nhân vật xem nào.",
				"Nhấn chọn trái để vào hành trang"
			},
			new string[]
			{
				"Đây là phần Thông tin nơi cung cấp cho bạn mọi thứ về chỉ số của bản thân",
				"Đây là 4 mục Sức mạnh, Khéo léo, Thể lực, Tin thần.",
				"Mỗi lần lên cấp thì mổi mục sẽ được cộng thêm 1 điểm",
				"Ngoài ra bạn sẽ có 5 điểm để cộng thêm vào, và cộng vào đâu, đúng hay sai do chính bạn quyết định.",
				"Phần bên dưới chính là toàn bộ thông tin về chỉ số của bạn",
				"Giờ ta hãy thử cộng vào Sức Khỏe vài điểm để thấy sự thay đổi.",
				"Di chuyển tới đây và nhấn chọn",
				"Rất tốt, chỉ số của bạn đã tăng lên 1 ít rồi.",
				"Khi lên cấp thì kỹ năng của bạn cũng được nâng cao, hãy vào xem thử nào.",
				"Di chuyển khung chọn tới đây"
			},
			new string[]
			{
				"Đây là phần Kỹ Năng, nơi cho bạn biết tất cả các tuyệt chiêu mình có thể học.",
				"Các dãy bên trái là kỹ năng Vật lý",
				"Khi muốn biết thông tin về kỹ năng đó bạn chỉ cần chọn vào nó.",
				"Bên phải là các kỹ năng ma thuật.",
				"Mỗi khi lên 1 cấp bạn sẽ có 1 điểm kỹ năng để cộng vào",
				"Và cũng như điểm tiềm năng cộng vào đâu đó là tùy quyết định của bạn.",
				"Giờ hãy cộng vào 1 kỹ năng, nhớ xem kỹ thông tin xem bạn thích hợp với cái nào hơn nha.",
				"Chọn vào 1 kỹ năng rồi nhấn cộng điểm",
				"Được rồi,và cũng như bình máu bạn có thể gán vào phím để sử dụng nhanh.",
				"Hãy gán vào 1 phím nào đó rồi ra ngoài kiểm tra sức mạnh của nó xem sao.",
				string.Empty
			},
			new string[]
			{
				"Bạn vừa nhận một nhiệm vụ mới,hãy vào Hành Trang - Nhân vật để xem lại thông tin nhiệm vụ đó nào.",
				"Di chuyển khung chọn tới đây",
				"Đây chính là mục nhiệm vụ giúp bạn quản lý thông tin nhiệm vụ của mình",
				"Thẻ bên trái là tổng hợp tất cả nhiệm vụ bạn đang làm.",
				"Thẻ bên phải là các nhiệm vụ đã xong và có thể trả.",
				"Khi muốn biết thêm thông tin về nhiệm vụ nào đó chỉ cần bạn di chuyển mục chọn tới đó, rồi nhấn xem.",
				"Bạn cũng có thể xem phần bản đồ lớn để biết rõ hơn về vị trí hiện tại cũng như nới cần phải đến.",
				string.Empty
			}
		};
		T.mHelpPoint = new string[][]
		{
			new string[]
			{
				string.Empty,
				string.Empty,
				"Dùng các phím điều hướng để di chuyển",
				"Bạn cũng có thể chạm vào các vùng trống trên màn hình nếu muốn di chuyển đến đó khi kich hoạt chức năng Touch",
				string.Empty
			},
			new string[]
			{
				Main.isPC ? "Rất tốt,tiếp tục nhé." : "Rất tốt,tiếp theo bạn hãy chạm vào đây để đánh 1 con quái.",
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Để vào đó bạn hãy nhấn vào Menu hoặc vào khung thông tin phía trên.",
				"Chạm vào đây để vào hành trang."
			},
			new string[]
			{
				string.Empty,
				string.Empty,
				"Hãy thử sử dụng bình máu bằng cách chạm vào bình máu",
				"Chạm 1 lần nữa để bất menu và chọn mục sử dụng",
				"Chạm vào đây và chọn sử dụng",
				string.Empty,
				string.Empty,
				"Hãy lại Chọn bình máu 1 lần nữa",
				string.Empty,
				"Chạm vào đây và chọn mục gán phím",
				"Chạm vào đây và chọn mục gán phím",
				string.Empty,
				string.Empty
			},
			new string[]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Chạm vào đây và chọn sử dụng",
				string.Empty,
				string.Empty,
				string.Empty,
				"Chạm vào đây để mở Trang Bị"
			},
			new string[]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Chạm vào đây để trở lại"
			},
			new string[]
			{
				string.Empty,
				"Đây là bản đồ nhỏ giúp bạn có 1 góc nhìn lớn hơn về khu vực đang đứng",
				"Hãy chú ý đến điểm chớp màu vàng trên bản đồ đó chính là nơi bạn cần đến",
				string.Empty,
				"Khi bạn chọn đến 1 mục tiêu nào đó thì thông tin mục tiêu sẻ hiện ở đây.",
				"Nếu muốn thay đổi mục tiêu bạn chỉ cần chạm vào mục tiêu đó.",
				"Bạn có đến 2 thanh kỹ năng hãy chạm vào đây để thay đổi",
				"Khi cần giao tiếp những người đứng gần thì hãy chạm vào đây để chat nha."
			},
			new string[]
			{
				string.Empty,
				string.Empty,
				"Chạm vào đây và chọn Hành trang-Nhân vật"
			},
			new string[]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Chạm vào đây để cộng điểm.",
				string.Empty,
				string.Empty,
				"Chạm vào đây để mở Kỹ Năng"
			},
			new string[]
			{
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				string.Empty,
				"Chọn vào 1 kỹ năng rồi nhấn cộng điểm",
				string.Empty,
				string.Empty,
				string.Empty
			},
			new string[]
			{
				string.Empty,
				"Chạm vào đây để mở Nhiệm Vụ",
				string.Empty,
				string.Empty,
				string.Empty,
				"Khi muốn biết thêm thông tin về nhiệm vụ nào đó bạn chỉ cần chạm vào nó.",
				string.Empty,
				string.Empty
			}
		};
	}

	// Token: 0x04000EF7 RID: 3831
	public static string thanhcong;

	// Token: 0x04000EF8 RID: 3832
	public static string thatbai;

	// Token: 0x04000EF9 RID: 3833
	public static string tathieuung;

	// Token: 0x04000EFA RID: 3834
	public static string bathieuung;

	// Token: 0x04000EFB RID: 3835
	public static string khac;

	// Token: 0x04000EFC RID: 3836
	public static string members;

	// Token: 0x04000EFD RID: 3837
	public static string thoigianconlai;

	// Token: 0x04000EFE RID: 3838
	public static string hetlannap;

	// Token: 0x04000EFF RID: 3839
	public static string hide;

	// Token: 0x04000F00 RID: 3840
	public static string hidefull;

	// Token: 0x04000F01 RID: 3841
	public static string annguoichoi;

	// Token: 0x04000F02 RID: 3842
	public static string hiennguoichoi;

	// Token: 0x04000F03 RID: 3843
	public static string hoihienguoichoi;

	// Token: 0x04000F04 RID: 3844
	public static string hoiannguoichoi;

	// Token: 0x04000F05 RID: 3845
	public static string trangbi1;

	// Token: 0x04000F06 RID: 3846
	public static string trangbi2;

	// Token: 0x04000F07 RID: 3847
	public static string quaylai;

	// Token: 0x04000F08 RID: 3848
	public static string hoprac;

	// Token: 0x04000F09 RID: 3849
	public static string bonguyenlieu;

	// Token: 0x04000F0A RID: 3850
	public static string can_not_move;

	// Token: 0x04000F0B RID: 3851
	public static string NghiBan;

	// Token: 0x04000F0C RID: 3852
	public static string nhapSlogan;

	// Token: 0x04000F0D RID: 3853
	public static string hoanthanh;

	// Token: 0x04000F0E RID: 3854
	public static string nhapsai;

	// Token: 0x04000F0F RID: 3855
	public static string hoidaugia;

	// Token: 0x04000F10 RID: 3856
	public static string nhapgiaban;

	// Token: 0x04000F11 RID: 3857
	public static string daugia;

	// Token: 0x04000F12 RID: 3858
	public static string gianHang;

	// Token: 0x04000F13 RID: 3859
	public static string numberHotLine;

	// Token: 0x04000F14 RID: 3860
	public static string HotLine;

	// Token: 0x04000F15 RID: 3861
	public static string TimeThachDau;

	// Token: 0x04000F16 RID: 3862
	public static string chuaboduclo;

	// Token: 0x04000F17 RID: 3863
	public static string DucLo;

	// Token: 0x04000F18 RID: 3864
	public static string muaNhieu;

	// Token: 0x04000F19 RID: 3865
	public static string bongoc;

	// Token: 0x04000F1A RID: 3866
	public static string hopngoc;

	// Token: 0x04000F1B RID: 3867
	public static string hetNgoc;

	// Token: 0x04000F1C RID: 3868
	public static string khongbothem;

	// Token: 0x04000F1D RID: 3869
	public static string chuaboitem;

	// Token: 0x04000F1E RID: 3870
	public static string bovao;

	// Token: 0x04000F1F RID: 3871
	public static string khamNgoc;

	// Token: 0x04000F20 RID: 3872
	public static string khongcongua;

	// Token: 0x04000F21 RID: 3873
	public static string Logifail;

	// Token: 0x04000F22 RID: 3874
	public static string TisNguaNau;

	// Token: 0x04000F23 RID: 3875
	public static string del;

	// Token: 0x04000F24 RID: 3876
	public static string username;

	// Token: 0x04000F25 RID: 3877
	public static string password;

	// Token: 0x04000F26 RID: 3878
	public static string login;

	// Token: 0x04000F27 RID: 3879
	public static string menu;

	// Token: 0x04000F28 RID: 3880
	public static string select;

	// Token: 0x04000F29 RID: 3881
	public static string close;

	// Token: 0x04000F2A RID: 3882
	public static string waitLogin;

	// Token: 0x04000F2B RID: 3883
	public static string nulluserpass;

	// Token: 0x04000F2C RID: 3884
	public static string next;

	// Token: 0x04000F2D RID: 3885
	public static string server;

	// Token: 0x04000F2E RID: 3886
	public static string create;

	// Token: 0x04000F2F RID: 3887
	public static string level;

	// Token: 0x04000F30 RID: 3888
	public static string namePlayer;

	// Token: 0x04000F31 RID: 3889
	public static string nameMin6char;

	// Token: 0x04000F32 RID: 3890
	public static string back;

	// Token: 0x04000F33 RID: 3891
	public static string remember;

	// Token: 0x04000F34 RID: 3892
	public static string hotKey;

	// Token: 0x04000F35 RID: 3893
	public static string congdiem;

	// Token: 0x04000F36 RID: 3894
	public static string phim;

	// Token: 0x04000F37 RID: 3895
	public static string Lv;

	// Token: 0x04000F38 RID: 3896
	public static string giaotiep;

	// Token: 0x04000F39 RID: 3897
	public static string createChar;

	// Token: 0x04000F3A RID: 3898
	public static string buy;

	// Token: 0x04000F3B RID: 3899
	public static string diemtiemnang;

	// Token: 0x04000F3C RID: 3900
	public static string diemkynang;

	// Token: 0x04000F3D RID: 3901
	public static string nhanvat;

	// Token: 0x04000F3E RID: 3902
	public static string mainQuest;

	// Token: 0x04000F3F RID: 3903
	public static string subQuest;

	// Token: 0x04000F40 RID: 3904
	public static string viewMap;

	// Token: 0x04000F41 RID: 3905
	public static string nhan;

	// Token: 0x04000F42 RID: 3906
	public static string tra;

	// Token: 0x04000F43 RID: 3907
	public static string cancel;

	// Token: 0x04000F44 RID: 3908
	public static string quest;

	// Token: 0x04000F45 RID: 3909
	public static string chat;

	// Token: 0x04000F46 RID: 3910
	public static string noMessage;

	// Token: 0x04000F47 RID: 3911
	public static string delTabChat;

	// Token: 0x04000F48 RID: 3912
	public static string read;

	// Token: 0x04000F49 RID: 3913
	public static string view;

	// Token: 0x04000F4A RID: 3914
	public static string change;

	// Token: 0x04000F4B RID: 3915
	public static string equip;

	// Token: 0x04000F4C RID: 3916
	public static string setPoint;

	// Token: 0x04000F4D RID: 3917
	public static string cong;

	// Token: 0x04000F4E RID: 3918
	public static string danglaydulieu;

	// Token: 0x04000F4F RID: 3919
	public static string hoihuyQuest;

	// Token: 0x04000F50 RID: 3920
	public static string hoiBuy;

	// Token: 0x04000F51 RID: 3921
	public static string pleaseWait;

	// Token: 0x04000F52 RID: 3922
	public static string leftRing;

	// Token: 0x04000F53 RID: 3923
	public static string rightRing;

	// Token: 0x04000F54 RID: 3924
	public static string hoiDelItem;

	// Token: 0x04000F55 RID: 3925
	public static string nhapsoluongcanmua;

	// Token: 0x04000F56 RID: 3926
	public static string khongcovatphanphuhop;

	// Token: 0x04000F57 RID: 3927
	public static string cong1diem;

	// Token: 0x04000F58 RID: 3928
	public static string nhapsodiem;

	// Token: 0x04000F59 RID: 3929
	public static string nhohonhoacbang;

	// Token: 0x04000F5A RID: 3930
	public static string cong1kynang;

	// Token: 0x04000F5B RID: 3931
	public static string setKey;

	// Token: 0x04000F5C RID: 3932
	public static string nhatdcvatpham;

	// Token: 0x04000F5D RID: 3933
	public static string farfocus;

	// Token: 0x04000F5E RID: 3934
	public static string party;

	// Token: 0x04000F5F RID: 3935
	public static string listParty;

	// Token: 0x04000F60 RID: 3936
	public static string noParty;

	// Token: 0x04000F61 RID: 3937
	public static string invite;

	// Token: 0x04000F62 RID: 3938
	public static string mainLeave;

	// Token: 0x04000F63 RID: 3939
	public static string leave;

	// Token: 0x04000F64 RID: 3940
	public static string mainCancle;

	// Token: 0x04000F65 RID: 3941
	public static string addFriend;

	// Token: 0x04000F66 RID: 3942
	public static string nullParty;

	// Token: 0x04000F67 RID: 3943
	public static string gianhap;

	// Token: 0x04000F68 RID: 3944
	public static string lapnhom;

	// Token: 0x04000F69 RID: 3945
	public static string khacclass;

	// Token: 0x04000F6A RID: 3946
	public static string buySell;

	// Token: 0x04000F6B RID: 3947
	public static string khoa;

	// Token: 0x04000F6C RID: 3948
	public static string fullBuySell;

	// Token: 0x04000F6D RID: 3949
	public static string kynangchuass;

	// Token: 0x04000F6E RID: 3950
	public static string price;

	// Token: 0x04000F6F RID: 3951
	public static string deleteFriend;

	// Token: 0x04000F70 RID: 3952
	public static string beginChat;

	// Token: 0x04000F71 RID: 3953
	public static string listFriend;

	// Token: 0x04000F72 RID: 3954
	public static string nullFriend;

	// Token: 0x04000F73 RID: 3955
	public static string hoivaonhom;

	// Token: 0x04000F74 RID: 3956
	public static string hoilapnhom;

	// Token: 0x04000F75 RID: 3957
	public static string item;

	// Token: 0x04000F76 RID: 3958
	public static string dungitem;

	// Token: 0x04000F77 RID: 3959
	public static string use;

	// Token: 0x04000F78 RID: 3960
	public static string underlevel;

	// Token: 0x04000F79 RID: 3961
	public static string chuahoc;

	// Token: 0x04000F7A RID: 3962
	public static string yeucau;

	// Token: 0x04000F7B RID: 3963
	public static string nangluong;

	// Token: 0x04000F7C RID: 3964
	public static string delay;

	// Token: 0x04000F7D RID: 3965
	public static string timebuff;

	// Token: 0x04000F7E RID: 3966
	public static string hieuung;

	// Token: 0x04000F7F RID: 3967
	public static string timehieuung;

	// Token: 0x04000F80 RID: 3968
	public static string tanghpdung;

	// Token: 0x04000F81 RID: 3969
	public static string tangmpdung;

	// Token: 0x04000F82 RID: 3970
	public static string phamvi;

	// Token: 0x04000F83 RID: 3971
	public static string phamvilan;

	// Token: 0x04000F84 RID: 3972
	public static string somuctieu;

	// Token: 0x04000F85 RID: 3973
	public static string banthan;

	// Token: 0x04000F86 RID: 3974
	public static string moinguoi;

	// Token: 0x04000F87 RID: 3975
	public static string trongdoi;

	// Token: 0x04000F88 RID: 3976
	public static string kethu;

	// Token: 0x04000F89 RID: 3977
	public static string buff;

	// Token: 0x04000F8A RID: 3978
	public static string active;

	// Token: 0x04000F8B RID: 3979
	public static string passive;

	// Token: 0x04000F8C RID: 3980
	public static string kynang;

	// Token: 0x04000F8D RID: 3981
	public static string velang;

	// Token: 0x04000F8E RID: 3982
	public static string muonvelang;

	// Token: 0x04000F8F RID: 3983
	public static string sell;

	// Token: 0x04000F90 RID: 3984
	public static string hoisell;

	// Token: 0x04000F91 RID: 3985
	public static string LVyeucau;

	// Token: 0x04000F92 RID: 3986
	public static string yeucauketban;

	// Token: 0x04000F93 RID: 3987
	public static string chapnhan;

	// Token: 0x04000F94 RID: 3988
	public static string tuchoi;

	// Token: 0x04000F95 RID: 3989
	public static string myseft;

	// Token: 0x04000F96 RID: 3990
	public static string info;

	// Token: 0x04000F97 RID: 3991
	public static string trochuyen;

	// Token: 0x04000F98 RID: 3992
	public static string moiParty;

	// Token: 0x04000F99 RID: 3993
	public static string vucbo;

	// Token: 0x04000F9A RID: 3994
	public static string coin;

	// Token: 0x04000F9B RID: 3995
	public static string gem;

	// Token: 0x04000F9C RID: 3996
	public static string hoithoat;

	// Token: 0x04000F9D RID: 3997
	public static string exit;

	// Token: 0x04000F9E RID: 3998
	public static string dangdangnhap;

	// Token: 0x04000F9F RID: 3999
	public static string hoiFrist;

	// Token: 0x04000FA0 RID: 4000
	public static string oldPlayer;

	// Token: 0x04000FA1 RID: 4001
	public static string newPlayer;

	// Token: 0x04000FA2 RID: 4002
	public static string register;

	// Token: 0x04000FA3 RID: 4003
	public static string help;

	// Token: 0x04000FA4 RID: 4004
	public static string clearData;

	// Token: 0x04000FA5 RID: 4005
	public static string lienhe;

	// Token: 0x04000FA6 RID: 4006
	public static string dacotaikhoan;

	// Token: 0x04000FA7 RID: 4007
	public static string dagoidangky;

	// Token: 0x04000FA8 RID: 4008
	public static string quenpass;

	// Token: 0x04000FA9 RID: 4009
	public static string thulai;

	// Token: 0x04000FAA RID: 4010
	public static string texthelpRegister;

	// Token: 0x04000FAB RID: 4011
	public static string lostMana;

	// Token: 0x04000FAC RID: 4012
	public static string capdochuadu;

	// Token: 0x04000FAD RID: 4013
	public static string nhandc;

	// Token: 0x04000FAE RID: 4014
	public static string diemcongvao;

	// Token: 0x04000FAF RID: 4015
	public static string hoisinh;

	// Token: 0x04000FB0 RID: 4016
	public static string newParty;

	// Token: 0x04000FB1 RID: 4017
	public static string oso;

	// Token: 0x04000FB2 RID: 4018
	public static string loimoiParty;

	// Token: 0x04000FB3 RID: 4019
	public static string moikhoinhom;

	// Token: 0x04000FB4 RID: 4020
	public static string giaitannhom;

	// Token: 0x04000FB5 RID: 4021
	public static string roikhoinhom;

	// Token: 0x04000FB6 RID: 4022
	public static string vuataonhom;

	// Token: 0x04000FB7 RID: 4023
	public static string disconnect;

	// Token: 0x04000FB8 RID: 4024
	public static string hoigiaodich;

	// Token: 0x04000FB9 RID: 4025
	public static string huygiaodich;

	// Token: 0x04000FBA RID: 4026
	public static string khongthegiaodich;

	// Token: 0x04000FBB RID: 4027
	public static string chuyentien;

	// Token: 0x04000FBC RID: 4028
	public static string nhapsotien;

	// Token: 0x04000FBD RID: 4029
	public static string xacnhan;

	// Token: 0x04000FBE RID: 4030
	public static string giaodichthanhcong;

	// Token: 0x04000FBF RID: 4031
	public static string giatrinhapsai;

	// Token: 0x04000FC0 RID: 4032
	public static string banmuongiaodich;

	// Token: 0x04000FC1 RID: 4033
	public static string xincho;

	// Token: 0x04000FC2 RID: 4034
	public static string setPk;

	// Token: 0x04000FC3 RID: 4035
	public static string dosat;

	// Token: 0x04000FC4 RID: 4036
	public static string on;

	// Token: 0x04000FC5 RID: 4037
	public static string off;

	// Token: 0x04000FC6 RID: 4038
	public static string hut;

	// Token: 0x04000FC7 RID: 4039
	public static string voigia;

	// Token: 0x04000FC8 RID: 4040
	public static string la;

	// Token: 0x04000FC9 RID: 4041
	public static string tinden;

	// Token: 0x04000FCA RID: 4042
	public static string khongthecong;

	// Token: 0x04000FCB RID: 4043
	public static string changeArea;

	// Token: 0x04000FCC RID: 4044
	public static string Area;

	// Token: 0x04000FCD RID: 4045
	public static string nhapsdt;

	// Token: 0x04000FCE RID: 4046
	public static string trora;

	// Token: 0x04000FCF RID: 4047
	public static string tinnhan;

	// Token: 0x04000FD0 RID: 4048
	public static string friend;

	// Token: 0x04000FD1 RID: 4049
	public static string logout;

	// Token: 0x04000FD2 RID: 4050
	public static string autoHP;

	// Token: 0x04000FD3 RID: 4051
	public static string auto;

	// Token: 0x04000FD4 RID: 4052
	public static string autoFire;

	// Token: 0x04000FD5 RID: 4053
	public static string timduongtoilang;

	// Token: 0x04000FD6 RID: 4054
	public static string again;

	// Token: 0x04000FD7 RID: 4055
	public static string nhanNv;

	// Token: 0x04000FD8 RID: 4056
	public static string traNv;

	// Token: 0x04000FD9 RID: 4057
	public static string tacdunglen;

	// Token: 0x04000FDA RID: 4058
	public static string mucdohoanthanh;

	// Token: 0x04000FDB RID: 4059
	public static string khongthetraodoi;

	// Token: 0x04000FDC RID: 4060
	public static string xinchogiaodich;

	// Token: 0x04000FDD RID: 4061
	public static string xacnhangiaodich;

	// Token: 0x04000FDE RID: 4062
	public static string chuyensang;

	// Token: 0x04000FDF RID: 4063
	public static string keypad;

	// Token: 0x04000FE0 RID: 4064
	public static string touch;

	// Token: 0x04000FE1 RID: 4065
	public static string Ring;

	// Token: 0x04000FE2 RID: 4066
	public static string menuChinh;

	// Token: 0x04000FE3 RID: 4067
	public static string chucnang;

	// Token: 0x04000FE4 RID: 4068
	public static string khuvuc;

	// Token: 0x04000FE5 RID: 4069
	public static string chimang;

	// Token: 0x04000FE6 RID: 4070
	public static string tatcasatthuong;

	// Token: 0x04000FE7 RID: 4071
	public static string satthuongvatly;

	// Token: 0x04000FE8 RID: 4072
	public static string satthuonglua;

	// Token: 0x04000FE9 RID: 4073
	public static string satthuongdoc;

	// Token: 0x04000FEA RID: 4074
	public static string satthuongdien;

	// Token: 0x04000FEB RID: 4075
	public static string nedon;

	// Token: 0x04000FEC RID: 4076
	public static string phongthu;

	// Token: 0x04000FED RID: 4077
	public static string hoihelp;

	// Token: 0x04000FEE RID: 4078
	public static string endHelp;

	// Token: 0x04000FEF RID: 4079
	public static string autoItem;

	// Token: 0x04000FF0 RID: 4080
	public static string dangketnoilai;

	// Token: 0x04000FF1 RID: 4081
	public static string vetruoc;

	// Token: 0x04000FF2 RID: 4082
	public static string toitruoc;

	// Token: 0x04000FF3 RID: 4083
	public static string listnull;

	// Token: 0x04000FF4 RID: 4084
	public static string suckhoe;

	// Token: 0x04000FF5 RID: 4085
	public static string yeusuckhoe;

	// Token: 0x04000FF6 RID: 4086
	public static string strhelp;

	// Token: 0x04000FF7 RID: 4087
	public static string tabtrangbi;

	// Token: 0x04000FF8 RID: 4088
	public static string tabthongtin;

	// Token: 0x04000FF9 RID: 4089
	public static string tabkynang;

	// Token: 0x04000FFA RID: 4090
	public static string tabnhiemvu;

	// Token: 0x04000FFB RID: 4091
	public static string tabhethong;

	// Token: 0x04000FFC RID: 4092
	public static string tabchucnang;

	// Token: 0x04000FFD RID: 4093
	public static string noichuyen;

	// Token: 0x04000FFE RID: 4094
	public static string download;

	// Token: 0x04000FFF RID: 4095
	public static string dcxuyengiap;

	// Token: 0x04001000 RID: 4096
	public static string dcchimang;

	// Token: 0x04001001 RID: 4097
	public static string tabhanhtrang;

	// Token: 0x04001002 RID: 4098
	public static string phansatthuong;

	// Token: 0x04001003 RID: 4099
	public static string mau;

	// Token: 0x04001004 RID: 4100
	public static string khangtatcast;

	// Token: 0x04001005 RID: 4101
	public static string xuyengiap;

	// Token: 0x04001006 RID: 4102
	public static string satthuongbang;

	// Token: 0x04001007 RID: 4103
	public static string giet;

	// Token: 0x04001008 RID: 4104
	public static string nhat;

	// Token: 0x04001009 RID: 4105
	public static string fullInven;

	// Token: 0x0400100A RID: 4106
	public static string helpCapchar;

	// Token: 0x0400100B RID: 4107
	public static string cauhinhthap;

	// Token: 0x0400100C RID: 4108
	public static string naptien;

	// Token: 0x0400100D RID: 4109
	public static string dangdungtocnay;

	// Token: 0x0400100E RID: 4110
	public static string dasohuu;

	// Token: 0x0400100F RID: 4111
	public static string chapnhanketban;

	// Token: 0x04001010 RID: 4112
	public static string hang;

	// Token: 0x04001011 RID: 4113
	public static string chuanhapsdt;

	// Token: 0x04001012 RID: 4114
	public static string chuanhapmk;

	// Token: 0x04001013 RID: 4115
	public static string sdtkhople;

	// Token: 0x04001014 RID: 4116
	public static string emailkhople;

	// Token: 0x04001015 RID: 4117
	public static string kiemtralai;

	// Token: 0x04001016 RID: 4118
	public static string sdt;

	// Token: 0x04001017 RID: 4119
	public static string email;

	// Token: 0x04001018 RID: 4120
	public static string nangcapyeucau;

	// Token: 0x04001019 RID: 4121
	public static string thongbaotuserver;

	// Token: 0x0400101A RID: 4122
	public static string khongganmauvaophimnay;

	// Token: 0x0400101B RID: 4123
	public static string questitem;

	// Token: 0x0400101C RID: 4124
	public static string layra;

	// Token: 0x0400101D RID: 4125
	public static string catvao;

	// Token: 0x0400101E RID: 4126
	public static string nhapsoluongcanlay;

	// Token: 0x0400101F RID: 4127
	public static string nhapsoluongcancat;

	// Token: 0x04001020 RID: 4128
	public static string sellmore;

	// Token: 0x04001021 RID: 4129
	public static string banhetxanh;

	// Token: 0x04001022 RID: 4130
	public static string banhettrang;

	// Token: 0x04001023 RID: 4131
	public static string khongcontrang;

	// Token: 0x04001024 RID: 4132
	public static string khongconxanh;

	// Token: 0x04001025 RID: 4133
	public static string dotrang;

	// Token: 0x04001026 RID: 4134
	public static string doxanh;

	// Token: 0x04001027 RID: 4135
	public static string chiphi;

	// Token: 0x04001028 RID: 4136
	public static string nguyenlieu;

	// Token: 0x04001029 RID: 4137
	public static string tilemayman;

	// Token: 0x0400102A RID: 4138
	public static string hoac;

	// Token: 0x0400102B RID: 4139
	public static string dapdo;

	// Token: 0x0400102C RID: 4140
	public static string hoidapxuluong;

	// Token: 0x0400102D RID: 4141
	public static string hay;

	// Token: 0x0400102E RID: 4142
	public static string setting;

	// Token: 0x0400102F RID: 4143
	public static string bovatphamvao;

	// Token: 0x04001030 RID: 4144
	public static string dapbangxu;

	// Token: 0x04001031 RID: 4145
	public static string chest;

	// Token: 0x04001032 RID: 4146
	public static string namenaptien;

	// Token: 0x04001033 RID: 4147
	public static string trochuyenvoi;

	// Token: 0x04001034 RID: 4148
	public static string noEvent;

	// Token: 0x04001035 RID: 4149
	public static string mevent;

	// Token: 0x04001036 RID: 4150
	public static string loimoikb;

	// Token: 0x04001037 RID: 4151
	public static string moivaoParty;

	// Token: 0x04001038 RID: 4152
	public static string loimoigiaodich;

	// Token: 0x04001039 RID: 4153
	public static string thachdau;

	// Token: 0x0400103A RID: 4154
	public static string hoithachdau;

	// Token: 0x0400103B RID: 4155
	public static string loimoithachdau;

	// Token: 0x0400103C RID: 4156
	public static string autoBuff;

	// Token: 0x0400103D RID: 4157
	public static string thongbao;

	// Token: 0x0400103E RID: 4158
	public static string hoichoniconclan;

	// Token: 0x0400103F RID: 4159
	public static string iconclan;

	// Token: 0x04001040 RID: 4160
	public static string contentclan;

	// Token: 0x04001041 RID: 4161
	public static string showAuto;

	// Token: 0x04001042 RID: 4162
	public static string addmemclan;

	// Token: 0x04001043 RID: 4163
	public static string moivaoclan;

	// Token: 0x04001044 RID: 4164
	public static string loimoivaoclan;

	// Token: 0x04001045 RID: 4165
	public static string clan;

	// Token: 0x04001046 RID: 4166
	public static string bieutuong;

	// Token: 0x04001047 RID: 4167
	public static string chuakhauhieu;

	// Token: 0x04001048 RID: 4168
	public static string xinvaoclan;

	// Token: 0x04001049 RID: 4169
	public static string xemdanhsach;

	// Token: 0x0400104A RID: 4170
	public static string gop;

	// Token: 0x0400104B RID: 4171
	public static string nhapsoxumuongop;

	// Token: 0x0400104C RID: 4172
	public static string nhapsoluongmuongop;

	// Token: 0x0400104D RID: 4173
	public static string doiSlogan;

	// Token: 0x0400104E RID: 4174
	public static string doiNoiquy;

	// Token: 0x0400104F RID: 4175
	public static string phonghacap;

	// Token: 0x04001050 RID: 4176
	public static string nhapthongtindoi;

	// Token: 0x04001051 RID: 4177
	public static string slogan;

	// Token: 0x04001052 RID: 4178
	public static string noiquy;

	// Token: 0x04001053 RID: 4179
	public static string thanhvien;

	// Token: 0x04001054 RID: 4180
	public static string chucvu;

	// Token: 0x04001055 RID: 4181
	public static string moiroiclan;

	// Token: 0x04001056 RID: 4182
	public static string roiclan;

	// Token: 0x04001057 RID: 4183
	public static string tabThuLinh;

	// Token: 0x04001058 RID: 4184
	public static string tabBangHoi;

	// Token: 0x04001059 RID: 4185
	public static string chattoanbang;

	// Token: 0x0400105A RID: 4186
	public static string doithongbao;

	// Token: 0x0400105B RID: 4187
	public static string bankhongconclan;

	// Token: 0x0400105C RID: 4188
	public static string soluong;

	// Token: 0x0400105D RID: 4189
	public static string donggopclan;

	// Token: 0x0400105E RID: 4190
	public static string quyxu;

	// Token: 0x0400105F RID: 4191
	public static string quyngoc;

	// Token: 0x04001060 RID: 4192
	public static string hoibatdosat;

	// Token: 0x04001061 RID: 4193
	public static string update;

	// Token: 0x04001062 RID: 4194
	public static string minimap;

	// Token: 0x04001063 RID: 4195
	public static string kenhthegioi;

	// Token: 0x04001064 RID: 4196
	public static string nhapnoidung;

	// Token: 0x04001065 RID: 4197
	public static string chatParty;

	// Token: 0x04001066 RID: 4198
	public static string phi;

	// Token: 0x04001067 RID: 4199
	public static string replace;

	// Token: 0x04001068 RID: 4200
	public static string hoichuyendo;

	// Token: 0x04001069 RID: 4201
	public static string qua;

	// Token: 0x0400106A RID: 4202
	public static string boitemreplace;

	// Token: 0x0400106B RID: 4203
	public static string dochuyen;

	// Token: 0x0400106C RID: 4204
	public static string donhan;

	// Token: 0x0400106D RID: 4205
	public static string plusnhanduoc;

	// Token: 0x0400106E RID: 4206
	public static string noidungnhusau;

	// Token: 0x0400106F RID: 4207
	public static string textkenhthegioi;

	// Token: 0x04001070 RID: 4208
	public static string text2kenhthegioi;

	// Token: 0x04001071 RID: 4209
	public static string nhanban;

	// Token: 0x04001072 RID: 4210
	public static string khongconhiemvu;

	// Token: 0x04001073 RID: 4211
	public static string timeyeucau;

	// Token: 0x04001074 RID: 4212
	public static string taoCanh;

	// Token: 0x04001075 RID: 4213
	public static string hoiTaoCanh;

	// Token: 0x04001076 RID: 4214
	public static string Lvsudung;

	// Token: 0x04001077 RID: 4215
	public static string nangcap;

	// Token: 0x04001078 RID: 4216
	public static string sudungsau;

	// Token: 0x04001079 RID: 4217
	public static string phandon;

	// Token: 0x0400107A RID: 4218
	public static string hoiroiClan;

	// Token: 0x0400107B RID: 4219
	public static string updateData;

	// Token: 0x0400107C RID: 4220
	public static string updateok;

	// Token: 0x0400107D RID: 4221
	public static string hoinangcapcanh;

	// Token: 0x0400107E RID: 4222
	public static string listserver;

	// Token: 0x0400107F RID: 4223
	public static string SetMusic;

	// Token: 0x04001080 RID: 4224
	public static string maychu;

	// Token: 0x04001081 RID: 4225
	public static string tuoi;

	// Token: 0x04001082 RID: 4226
	public static string tancong;

	// Token: 0x04001083 RID: 4227
	public static string choan;

	// Token: 0x04001084 RID: 4228
	public static string lockMap;

	// Token: 0x04001085 RID: 4229
	public static string delMess;

	// Token: 0x04001086 RID: 4230
	public static string khongthedung;

	// Token: 0x04001087 RID: 4231
	public static string about;

	// Token: 0x04001088 RID: 4232
	public static string textabout1;

	// Token: 0x04001089 RID: 4233
	public static string textabout2;

	// Token: 0x0400108A RID: 4234
	public static string nokiaprivacy;

	// Token: 0x0400108B RID: 4235
	public static string thoigianaptrung;

	// Token: 0x0400108C RID: 4236
	public static string aptrung;

	// Token: 0x0400108D RID: 4237
	public static string nhaptaikhoan;

	// Token: 0x0400108E RID: 4238
	public static string choimoi;

	// Token: 0x0400108F RID: 4239
	public static string moly;

	// Token: 0x04001090 RID: 4240
	public static string startdraw;

	// Token: 0x04001091 RID: 4241
	public static string choitiep;

	// Token: 0x04001092 RID: 4242
	public static string choi;

	// Token: 0x04001093 RID: 4243
	public static string chonlai;

	// Token: 0x04001094 RID: 4244
	public static string choi_daco_TK;

	// Token: 0x04001095 RID: 4245
	public static string daco_TK;

	// Token: 0x04001096 RID: 4246
	public static string doi_TK_khac;

	// Token: 0x04001097 RID: 4247
	public static string minutes;

	// Token: 0x04001098 RID: 4248
	public static string yes;

	// Token: 0x04001099 RID: 4249
	public static string no;

	// Token: 0x0400109A RID: 4250
	public static string hopNguyenLieu;

	// Token: 0x0400109B RID: 4251
	public static string hopThanh;

	// Token: 0x0400109C RID: 4252
	public static string YOUNEED;

	// Token: 0x0400109D RID: 4253
	public static string backBattlefield;

	// Token: 0x0400109E RID: 4254
	public static string infoArena;

	// Token: 0x0400109F RID: 4255
	public static string textXuongNgua;

	// Token: 0x040010A0 RID: 4256
	public static string textHoiXuongNgua;

	// Token: 0x040010A1 RID: 4257
	public static string speedUp;

	// Token: 0x040010A2 RID: 4258
	public static string Tips;

	// Token: 0x040010A3 RID: 4259
	public static string TchangSv;

	// Token: 0x040010A4 RID: 4260
	public static string TuseNgua;

	// Token: 0x040010A5 RID: 4261
	public static string[] textCreateChar;

	// Token: 0x040010A6 RID: 4262
	public static string[] mClass;

	// Token: 0x040010A7 RID: 4263
	public static string[] mKyNang;

	// Token: 0x040010A8 RID: 4264
	public static string[] story;

	// Token: 0x040010A9 RID: 4265
	public static string[] mColorPk;

	// Token: 0x040010AA RID: 4266
	public static string[] mAuto;

	// Token: 0x040010AB RID: 4267
	public static string[] mUtien;

	// Token: 0x040010AC RID: 4268
	public static string[] helpMenu;

	// Token: 0x040010AD RID: 4269
	public static string[] mAutoItem;

	// Token: 0x040010AE RID: 4270
	public static string[] mhang;

	// Token: 0x040010AF RID: 4271
	public static string[] mChucVuClan;

	// Token: 0x040010B0 RID: 4272
	public static string[] mVolume;

	// Token: 0x040010B1 RID: 4273
	public static string[] mQuest;

	// Token: 0x040010B2 RID: 4274
	public static string[] mKynangPet;

	// Token: 0x040010B3 RID: 4275
	public static string[] mQuickChat;

	// Token: 0x040010B4 RID: 4276
	public static string[] mTips;

	// Token: 0x040010B5 RID: 4277
	public static string[] mapName;

	// Token: 0x040010B6 RID: 4278
	public static string[][] mCreateChar_HAIR;

	// Token: 0x040010B7 RID: 4279
	public static string[][] mCreateChar_EYE_FACE;

	// Token: 0x040010B8 RID: 4280
	public static string[][] mHelp;

	// Token: 0x040010B9 RID: 4281
	public static string[][] mHelpPoint;

	// Token: 0x040010BA RID: 4282
	public static string[][] mValueAutoItem;

	// Token: 0x040010BB RID: 4283
	public static string changeScrennSmall;

	// Token: 0x040010BC RID: 4284
	public static string normalScreen;

	// Token: 0x040010BD RID: 4285
	public static string changeSizeScreen;
}
