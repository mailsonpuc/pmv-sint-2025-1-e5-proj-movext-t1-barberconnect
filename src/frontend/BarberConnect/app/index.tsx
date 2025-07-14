
import { Link } from 'expo-router';
import { StyleSheet, Text, View } from 'react-native';
import { Button } from 'react-native-paper';

export default function HomeScreen() {
  return (
    <View style={styles.container}>
      <Text>BarberConnect</Text>
     
      
      <Link href="/Cadastrar"><Button icon="account-circle">Cadastrar</Button></Link>
      <Link href="/BotaoNavegacao"><Button icon="account-circle">Entrar</Button></Link>

    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
});
