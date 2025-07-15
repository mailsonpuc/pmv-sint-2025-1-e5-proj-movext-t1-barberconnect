import * as React from 'react';
import { BottomNavigation, Provider as PaperProvider, Text } from 'react-native-paper';
import { View, StyleSheet } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

const InicioRoute = () => (
  <View style={styles.content}>
    <Text>Inicio</Text>
  </View>
);

const ServicosRoute = () => (
  <View style={styles.content}>
    <Text>Serviços</Text>
  </View>
);

const NotificationsRoute = () => (
  <View style={styles.content}>
    <Text>Notificações</Text>
  </View>
);

const ContaRoute = () => {
  const [username, setUsername] = React.useState('');

  React.useEffect(() => {
    const fetchUsername = async () => {
      try {
        const storedUsername = await AsyncStorage.getItem('username');
        if (storedUsername) {
          setUsername(storedUsername);
        }
      } catch (error) {
        console.error('Erro ao buscar username:', error);
      }
    };
    fetchUsername();
  }, []);

  return (
    <View style={styles.content}>
      <Text>Olá, {username || 'usuário'}!</Text>
    </View>
  );
};

const BotaoNavegacao = () => {
  const [index, setIndex] = React.useState(0);
  const [routes] = React.useState([
    { key: 'inicio', title: 'Inicio', focusedIcon: 'warehouse' },
    { key: 'servicos', title: 'Serviços', focusedIcon: 'apps' },
    { key: 'conta', title: 'Conta', focusedIcon: 'account' },
    { key: 'notifications', title: 'Notificações', focusedIcon: 'bell' },
  ]);

  const renderScene = BottomNavigation.SceneMap({
    inicio: InicioRoute,
    servicos: ServicosRoute,
    conta: ContaRoute,
    notifications: NotificationsRoute,
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

const styles = StyleSheet.create({
  content: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
});
