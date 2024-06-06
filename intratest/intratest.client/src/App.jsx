import { useEffect, useState } from 'react';
import './App.css';
import coin1 from './assets/coin1.png';
import coin2 from './assets/coin2.png';
import coin5 from './assets/coin5.png';
import coin10 from './assets/coin10.png';
import React from 'react'

class DrinkButton extends React.Component {

    constructor(props) {
        super(props);
        this.drink = this.props.drinkInst;
        this.state = { isActive: false, lightElement: {}, count: this.props.drinkInst.quantity};
        this.press = this.press.bind(this);
    }

    componentDidUpdate(prevProps) {
        if (prevProps.drinkInst !== this.props.drinkInst) {
            this.setState({ count: this.props.drinkInst.quantity })
        }
    }

    press(e) {
        e.preventDefault();
        if (this.props.currentMoney >= this.drink.cost && !this.state.isActive) {
            let [className, styleName] = (this.state.isActive === false) ? [true, { "boxShadow": "0px 0px 7px #F86868" }] : [false, {}];
            this.setState({ isActive: className, lightElement: styleName });
            this.props.changeMoney(this.props.currentMoney - this.drink.cost);
            this.props.idsCount.push(this.drink.id)
            this.props.changeDrink(this.props.idsCount);
        }
        else if (this.state.isActive) {
            let [className, styleName] = (this.state.isActive === false) ? [true, { "boxShadow": "0px 0px 7px #F86868" }] : [false, {}];
            this.setState({ isActive: className, lightElement: styleName });
            this.props.changeMoney(this.props.currentMoney + this.drink.cost)
            let index = this.props.idsCount.indexOf(this.drink.id);
            if (index !== -1) {
                this.props.idsCount.splice(index, 1)
                this.props.changeDrink(this.props.idsCount);
            }
        }

    }

    render() {
        let styleName = this.state.lightElement;
        return <button onClick={this.press} className='drinkItem' style={styleName} id={this.drink.id}>
            <img className="drinkImg" src={this.drink.path}></img><br />
            {this.drink.name}<br />
            Цена: {this.drink.cost}<br />
            Кол-во: {this.state.count}<br />
        </button>
    }
}

function App() {

    const [drinks, setDrinks] = useState();
    const [money, setMoney] = useState(0);
    const [coinCount1, setCoinCount1] = useState();
    const [coinCount2, setCoinCount2] = useState();
    const [coinCount5, setCoinCount5] = useState();
    const [coinCount10, setCoinCount10] = useState();
    const [idsCount, setIdsCount] = useState([]);
    const [coin1Style, setCoin1Style] = useState([]);
    const [coin2Style, setCoin2Style] = useState([]);
    const [coin5Style, setCoin5Style] = useState([]);
    const [coin10Style, setCoin10Style] = useState([]);


    useEffect(() => {
        translateDrinksData();
    }, []);


    useEffect(() => {
        setCoinCount1(getRandomInt(1, 40));
        setCoinCount2(getRandomInt(1, 40));
        setCoinCount5(getRandomInt(1, 40));
        setCoinCount10(getRandomInt(1, 40));
    }, [])

    const contents = drinks === undefined
        ? <p>Загрузка...</p>
        : <div id="mainMenu">
            <div id="drinkTable">
                {drinks.map(drink => <DrinkButton idsCount={idsCount} changeDrink={setIdsCount} changeMoney={setMoney} currentMoney={money} id={drink.id} key={drink.id} drinkInst={drink} />)}
            </div>
            <div id="buyMenu">
                <p id="moneyCounter" className="kaisei-opti-regular">{money} р</p>
                <button id="buyButton" onClick={sendData}><span>Купить</span></button>
            </div>
            
            <div id="coins">
                <label>{coinCount1} <button style={ coin1Style } id="coin1" onClick={coinClick}><img src={coin1}></img></button></label>
                <label>{coinCount2}<button style={coin2Style} id="coin2" onClick={coinClick}><img src={coin2}></img></button></label>
                <label>{coinCount5}<button style={coin5Style} id="coin5" onClick={coinClick}><img src={coin5}></img></button></label>
                <label>{coinCount10}<button style={coin10Style} id="coin10" onClick={coinClick}><img src={coin10}></img></button></label>
            </div>
        </div>;


    return (
        <div>
            {contents}
        </div>
    );

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    async function sendData() {
        await fetch('drink', {
            method: 'PATCH',
            body: JSON.stringify(idsCount),
            headers: {
                "Content-Type": "application/json"
            }
        }).then(res => res.json()).then((result) => (setDrinks([ ...result ].map(i => i))));
    }

    function coinClick(e) {
        e.preventDefault();
        switch (e.currentTarget.id) {
            case 'coin1': if (coinCount1 > 0) (setMoney(money + 1), setCoinCount1(coinCount1 - 1));
                if (coinCount1 - 1 == 0) setCoin1Style({"filter": "brightness(0.5)"});
                break;
            case 'coin2': if (coinCount2 > 0) (setMoney(money + 2), setCoinCount2(coinCount2 - 1));
                if (coinCount2 - 1 == 0) setCoin2Style({ "filter": "brightness(0.5)" });
                break;
            case 'coin5': if (coinCount5 > 0) (setMoney(money + 5), setCoinCount5(coinCount5 - 1));
                if (coinCount5 - 1 == 0) setCoin5Style({ "filter": "brightness(0.5)" });
                break;
            case 'coin10': if (coinCount10 > 0) (setMoney(money + 10), setCoinCount10(coinCount10 - 1));
                if (coinCount10 - 1 == 0) setCoin10Style({ "filter": "brightness(0.5)" });
                break;


        }
    }

    async function translateDrinksData() {
        const response = await fetch('drink')
        const data = await response.json()
        await setDrinks(data);
    }
}

export default App;