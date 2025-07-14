import * as React from 'react';
import { BottomNavigation, Provider as PaperProvider, Text } from 'react-native-paper';

const InicioRoute = () => <Text>Inicio</Text>;
const ServicosRoute = () => <Text>Serviços</Text>;
const NotificationsRoute = () => <Text>Notifications</Text>;
const ContaRoute = () => <Text>Conta</Text>;

const BotaoNavegacao = () => {
    const [index, setIndex] = React.useState(0);
    const [routes] = React.useState([
        { key: 'inicio', title: 'Inicio', focusedIcon: 'warehouse', unfocusedIcon: 'warehouse' },
        { key: 'servicos', title: 'Servicos', focusedIcon: 'apps' },
        { key: 'conta', title: 'Conta', focusedIcon: 'account' },

        { key: 'notifications', title: 'Notifications', focusedIcon: 'bell', unfocusedIcon: 'bell-outline' },
    ]);

    const renderScene = BottomNavigation.SceneMap({
        inicio: InicioRoute,
        servicos: ServicosRoute,

        notifications: NotificationsRoute,
        conta: ContaRoute,
    });

    return (
        <BottomNavigation
            navigationState={{ index, routes }}
            onIndexChange={setIndex}
            renderScene={renderScene}
        />
    );
};

export default function Index() {
    return (
        <PaperProvider>
            <BotaoNavegacao />
        </PaperProvider>
    );
}
