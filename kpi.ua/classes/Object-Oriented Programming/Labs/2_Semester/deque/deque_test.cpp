/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Лабораторная работа №4 (2-ой семестр 2008)
 *	(домашняя контрольная работа)
 *
 *		Выполнил:
 * Подольский Сергей
 * группа: КВ-64
 *
 *		Описание проекта:
 * chunk.h			содержит параметризированный класс, представляющий кусок контейнера _chunk
 * iterator.h		содержит параметризированный класс iterator
 * deque.h			содержит параметризированный класс deque
 * vehicle.h		содержит класс vehicle
 * deque_test.h		тест-драйв, предоставляющий пользовательское меню
 * data.csv			файл исходных данных об автомобилях в csv-формате
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

#include "deque.h"
#include "vehicle.h"

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Пользовательский интерфейс
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

deque<vehicle> d;

char *RequestFromFile(){
	cout << "Enter file path" << endl;
	string path;
	cin >> path;
	if (d.FromFile(path)) return ">LOADED SUCCESSFULLY";
	return ">FAILED: BAD FILE";
}

void RequestPrint(){
	if (d.empty()) cout << ">DEQUE IS EMPTY" << endl;
	else cout << d << endl;
}

char *RequestPushFront(){
	cout << "Enter new vehicle in csv-format" << endl;
	vehicle tmp;
	cin >> tmp;
	d.push_front(tmp);
	return ">ADDED SUCCESSFULLY";
}

char *RequestPushBack(){
	cout << "Enter new vehicle in csv-format" << endl;
	vehicle tmp;
	cin >> tmp;
	d.push_back(tmp);
	return ">ADDED SUCCESSFULLY";
}

char *RequestPopFront(){
	if (d.empty()) return ">DEQUE IS EMPTY";
	d.pop_front();
	return ">REMOVED SUCCESSFULLY";
}

char *RequestPopBack(){
	if (d.empty()) return ">DEQUE IS EMPTY";
	d.pop_back();
	return ">REMOVED SUCCESSFULLY";
}

char *RequestInsert(){
	cout << "Enter new vehicle in csv-format" << endl;
	vehicle tmp;
	cin >> tmp;
	cout << "Enter index" << endl;
	size_type indx;
	cin >> indx;
	if (indx < 0) return ">ERROR: index below zero";
	if (indx > d.size()) return ">ERROR: index above deque's size";
	d.insert(d.begin() + indx, tmp);
	return ">ADDED SUCCESSFULLY";
}

char *RequestErase(){
	cout << "Enter start index" << endl;
	int i1;
	cin >> i1;
	if (i1 < 0) return ">ERROR: start index below zero";
	if (i1 >= d.size()) return ">ERROR: start index above deque's size";
	cout << "Enter end index" << endl;
	int i2;
	cin >> i2;
	if (i2 < 0) return ">ERROR: end index below zero";
	if (i2 >= d.size()) return ">ERROR: end index above deque's size";
	if (i1 > i2) return ">ERROR: start index above end index";
	d.erase(d.begin() + i1, d.begin() + i2);
	return ">REMOVED SUCCESSFULLY";
}

char *RequestFront(){
	if (d.empty()) return ">DEQUE IS EMPTY";
	cout << d.front();
	return "";
}

char *RequestBack(){
	if (d.empty()) return ">DEQUE IS EMPTY";
	cout << d.back();
	return "";
}

/**** рекурсивный вывод пользовательского меню ****/
void Request(){
	cout << "'1' - Load deque<vehicle> from file" << endl;
	cout << "'2' - Print deque" << endl;
	cout << "'3' - Push front vehicle" << endl;
	cout << "'4' - Push back vehicle" << endl;
	cout << "'5' - Pop front" << endl;
	cout << "'6' - Pop back" << endl;
	cout << "'7' - Insert vehicle" << endl;
	cout << "'8' - Erase range" << endl;
	cout << "'9' - Clear" << endl;
	cout << "'10' - Get front" << endl;
	cout << "'11' - Get back" << endl;
	cout << "'12' - Get size" << endl;
	cout << "'0' - Exit" << endl;

	string s;
	cin >> s;

	if ("1" == s) cout << RequestFromFile() << endl;
	else if ("2" == s) RequestPrint();
	else if ("3" == s) cout << RequestPushFront() << endl;
	else if ("4" == s) cout << RequestPushBack() << endl;
	else if ("5" == s) cout << RequestPopFront() << endl;
	else if ("6" == s) cout << RequestPopBack() << endl;
	else if ("7" == s) cout << RequestInsert() << endl;
	else if ("8" == s) cout << RequestErase() << endl;
	else if ("9" == s) {d.clear(); RequestPrint();}
	else if ("10" == s) cout << RequestFront() << endl;
	else if ("11" == s) cout << RequestBack() << endl;
	else if ("12" == s) cout << ">SIZE = " << d.size() << endl;
	else if ("0" == s) exit(1);

	Request();
}

/***** MAIN ******/
int main(){
	Request();
	return 0;
}
