import cv2

coordinates = []


def click_event(event, x, y, flags, param):
    if event == cv2.EVENT_LBUTTONDOWN:
        coordinates.append(x)
        coordinates.append(y)   
        print("點擊座標 (x, y):", x, y)

# 讀取圖片
image = cv2.imread('/Users/shaoxi/Desktop/1234.png')  # 替換成你的圖片路徑


cv2.imshow('image', image)


cv2.setMouseCallback('image', click_event)


while True:
    key = cv2.waitKey(1) & 0xFF
    if key == ord('q'):
        break


print(coordinates)


cv2.destroyAllWindows()



